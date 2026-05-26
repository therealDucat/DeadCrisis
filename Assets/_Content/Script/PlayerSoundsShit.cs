using System;
using _Content.Script.Utils;
using FMODUnity;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerSoundsShit : MonoBehaviour
{
	[Header("Sounds")]
    public EventReference damageSound;
    public EventReference deathSound;
    public EventReference stepSounds;
    public EventReference swapWeaponSound;
	
    private Transform _cachedTransform = null;
    public Transform cachedTransform { 
        get { 
            if ( _cachedTransform ) { 
                return _cachedTransform; 
            } else { 
                _cachedTransform = transform;
                return _cachedTransform; 
            }  
        } 
    }
    
}
