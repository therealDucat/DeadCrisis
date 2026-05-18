using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VolumeHelper : MonoBehaviour
{
    public Volume volume;
    
    private Bloom _bloom = null;
    private ColorAdjustments _colorAdjustments = null;
    private FilmGrain _filmGrain = null;
    private ChromaticAberration _chromaticAberration = null;
    private Vignette _vignette = null;
    
    void Start()
    {
        // Получение настроек постпроцессинга из VolumeProfile
        volume.profile.TryGet(out _bloom);
        volume.profile.TryGet(out _colorAdjustments);
        volume.profile.TryGet(out _filmGrain);
        volume.profile.TryGet(out _chromaticAberration);
        volume.profile.TryGet(out _vignette);
    }
    
    // Интенсивность bloom
    public void BloomIntensity(float bloomIntensity) 
    {
        if (_bloom != null)
        {
            _bloom.intensity.value = bloomIntensity;
        }
        else
        {
            Debug.LogWarning("Bloom effect is not initialized.");
        }
    }
    // Выключение Bloom
    public void BloomToggle(bool bloomToggle)
    {
        if (_bloom != null)
        {
            _bloom.active = bloomToggle;
        }
        else
        {
            Debug.LogWarning("Bloom effect is not initialized.");
        }
    }
    // Насыщенность цвета
    public void ColorSaturation(float saturation) 
    {
        if (_colorAdjustments != null)
        {
            _colorAdjustments.saturation.value = saturation;
        }
        else
        {
            Debug.LogWarning("Color Adjustments is not initialized.");
        }
    }
    // Выключение Film Garain
    public void GrainToggle(bool grainToggle) 
    {
        if (_filmGrain != null)
        {
            _filmGrain.active = grainToggle;
        }
        else
        {
            Debug.LogWarning("Film Grain effect is not initialized.");
        }
    }

    // Выключение Chromatic Aberration
    public void ChromaticToggle(bool chromaticToggle) 
    {
        if (_chromaticAberration != null)
        {
            _chromaticAberration.active = chromaticToggle;
        }
        else
        {
            Debug.LogWarning("Chromatic Aberration is not initialized.");
        }
    }
    // Интенсивность Chromatic Aberration
    public void ChromaticIntense(float chromaticIntense) 
    {
        if (_chromaticAberration != null)
        {
            _chromaticAberration.intensity.value = chromaticIntense;
        }
        else
        {
            Debug.LogWarning("Chromatic Aberration is not initialized.");
        }
    }
    // Выключение Vignette
    public void VignetteToggle(bool vignetteToggle) 
    {
        if (_vignette != null)
        {
            _vignette.active = vignetteToggle;
        }
        else
        {
            Debug.LogWarning("Vignette effect is not initialized.");
        }
    }
}
