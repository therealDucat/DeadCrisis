using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using STOP_MODE = FMOD.Studio.STOP_MODE;
using _Content.Script.Utils;

namespace _Content.Script.Utils
{
    public class FMODManager: Singleton<FMODManager>
    {
        private Dictionary<string, EventInstance> eventInstances = new();
        private List<EventInstance> lastPlayedInstances = new();
        
        private Bus masterBus;
        private Bus cutsceneBus;
        private Bus musicBus;
        private Bus sfxBus;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            
            masterBus = RuntimeManager.GetBus("bus:/");
            cutsceneBus = RuntimeManager.GetBus("bus:/Cutscene");
            musicBus = RuntimeManager.GetBus("bus:/Music");
            sfxBus = RuntimeManager.GetBus("bus:/SFX");

            ClearPlaySounds().Forget();
        }

        private async UniTask ClearPlaySounds()
        {
            while (true)
            {
                for (var i = 0; i < lastPlayedInstances.Count; i++)
                {
                    var playedInstance = lastPlayedInstances[i];
                    playedInstance.getPlaybackState(out var state);
                    if (state == PLAYBACK_STATE.STOPPED)
                    {
                        lastPlayedInstances.RemoveAt(i);
                    }
                }

                await UniTask.Delay(3000);
            }
        }


        public void Cutscene(bool mute)
        {
            cutsceneBus.setMute(mute);
            musicBus.setMute(!mute);
            sfxBus.setMute(!mute);
        }

        public void Pause(bool pause)
        {
            foreach (var sound in lastPlayedInstances)
                sound.setPaused(pause);
        }
        
        public void PauseAll(bool pause)
        {
            var sounds = lastPlayedInstances.Union(eventInstances.Values);
            foreach (var sound in sounds)
                sound.setPaused(pause);
        }

        public EventInstance PlaySound(GUID guid, Vector3 position = default(Vector3), 
            EVENT_CALLBACK callback = null, EVENT_CALLBACK_TYPE type = EVENT_CALLBACK_TYPE.SOUND_PLAYED)
        {
            if(guid.IsNull) return default;
            var eventInstance = RuntimeManager.CreateInstance(guid);
            if (position != default)
            {
                eventInstance.set3DAttributes(position.To3DAttributes());
            }

            if (callback != null)
                eventInstance.setCallback(callback, type);
            
            eventInstance.start();
            eventInstance.release();
            lastPlayedInstances.Add(eventInstance);
            return eventInstance;
        }

        public EventInstance PlaySoundWithParameter(GUID guid, Parameters[] parameters, Vector3 position = default)
        {
            if(guid.IsNull) return default;
            var eventInstance = RuntimeManager.CreateInstance(guid);
            if (position != default)
            {
                eventInstance.set3DAttributes(position.To3DAttributes());
            }

            foreach (var parameter in parameters)
                eventInstance.setParameterByName(parameter.parameterName, parameter.value);
            
            eventInstance.start();
            eventInstance.release();
            lastPlayedInstances.Add(eventInstance);
            return eventInstance;
        }
        
        public void SetMasterVolume(float volume)
        {
            masterBus.setVolume(volume);
        }
        
        public void SetMusicVolume(float volume)
        {
            musicBus.setVolume(volume);
        }

        public void SetSFXVolume(float volume)
        {
            sfxBus.setVolume(volume);
            cutsceneBus.setVolume(volume);
        }
        
        public void StopAllSounds()
        {
            foreach (var eventInstance in eventInstances.Values.Union(lastPlayedInstances))
            {
                eventInstance.stop(STOP_MODE.IMMEDIATE);
            }

            sfxBus.stopAllEvents(STOP_MODE.IMMEDIATE);
            
            eventInstances.Clear();
        }

        public void SetParameter(GUID guid, string parameterName, float parameterValue)
        {
            if (eventInstances.ContainsKey(guid.ToString()))
            {
                var eventInstance = eventInstances[guid.ToString()];
                eventInstance.setParameterByName(parameterName, parameterValue);
            }
        }
        
        public EventInstance PlayPersistentSound(GUID guid, string name, Vector3 position = default)
        {
            if(guid.IsNull || string.IsNullOrEmpty(name)) return default;
            if (!eventInstances.ContainsKey(name))
            {
                var eventInstance = RuntimeManager.CreateInstance(guid);
                if (position != default)
                {
                    eventInstance.set3DAttributes(position.To3DAttributes());
                }
                eventInstance.start();
                eventInstances[name] = eventInstance;
                lastPlayedInstances.Add(eventInstance);
            }

            return eventInstances[name];
        }

        public void AttachToTransform(GUID guid, string name, Transform transform)
        {
            if(guid.IsNull || string.IsNullOrEmpty(name)) return;
            if (eventInstances.TryGetValue(name, out var eventInstance))
            {
                RuntimeManager.AttachInstanceToGameObject(eventInstance, transform);
            }
        }

        public void StopPersistentSound(string name)
        {
            if (eventInstances.ContainsKey(name))
            {
                var eventInstance = eventInstances[name];
                eventInstance.stop(global::FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                eventInstances.Remove(name);
            }
        }
        
        public EventInstance PlaySound(EventReference eventRef, Vector3 position = default(Vector3)) => 
            PlaySound(eventRef.Guid, position);
        
        public EventInstance PlaySound(EventReference eventRef, Vector3 position = default(Vector3),
            EVENT_CALLBACK callback = null, EVENT_CALLBACK_TYPE type = EVENT_CALLBACK_TYPE.SOUND_PLAYED) => 
            PlaySound(eventRef.Guid, position, callback, type);

        public EventInstance PlaySoundWithParameter(EventReference eventRef, string parameterName,
            float parameterValue, Vector3 position = default) =>
            PlaySoundWithParameter(eventRef.Guid, new []{new Parameters(parameterName, parameterValue)}, position);
        
        public EventInstance PlaySoundWithParameter(EventReference eventRef, Parameters[] parameters, Vector3 position = default) =>
            PlaySoundWithParameter(eventRef.Guid, parameters, position);

        public void SetParameter(EventReference eventRef, string parameterName, float parameterValue) =>
            SetParameter(eventRef.Guid, parameterName, parameterValue);

        public EventInstance PlayPersistentSound(EventReference eventRef, Vector3 position = default) =>
            PlayPersistentSound(eventRef.Guid, eventRef.Guid.ToString(), position);
        
        public EventInstance PlayPersistentSound(EventReference eventRef, string name, Vector3 position = default) =>
            PlayPersistentSound(eventRef.Guid, name, position);

        public void AttachToTransform(EventReference eventRef, string name, Transform transform) =>
            AttachToTransform(eventRef.Guid, name, transform);
        
        public void AttachToTransform(EventReference eventRef, Transform transform) =>
            AttachToTransform(eventRef.Guid, eventRef.Guid.ToString(), transform);

        public void StopPersistentSound(EventReference eventRef) => StopPersistentSound(eventRef.Guid.ToString());

        [Serializable]
        public struct Parameters
        {
            public string parameterName;
            public float value;

            public Parameters(string parameterName, float value)
            {
                this.parameterName = parameterName;
                this.value = value;
            }
        }

        public void AddInstanceToHistory(EventInstance instance)
        {
            lastPlayedInstances.Add(instance);
        }

        public void RemoveFromHistory(EventInstance instance)
        {
            lastPlayedInstances.Remove(instance);
        }
    }
}