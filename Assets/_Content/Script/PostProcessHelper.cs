using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessHelper : MonoBehaviour
{
    private PostProcessProfile postProcess;

    void Start()
    {
      var Volume = gameObject.GetComponent<PostProcessVolume>();
       postProcess = Volume.profile;
}




    public void AO_Enable(bool value)
    {
        AmbientOcclusion _ao = null;
        postProcess.TryGetSettings(out _ao);
        _ao.enabled.value = value;
    }
       
    public void AO_Mode(AmbientOcclusionMode value)
    {
        AmbientOcclusion _ao = null;
        postProcess.TryGetSettings(out _ao);
        _ao.mode.value = value;
    }
    
    public void AO_Intensity(float value)
    {
        AmbientOcclusion _ao = null;
        postProcess.TryGetSettings(out _ao);
        _ao.intensity.value = value;
    }

    public void AO_Thickness_Modifier(float value)
    {
        AmbientOcclusion _ao = null;
        postProcess.TryGetSettings(out _ao);
        _ao.thicknessModifier.value = value;
    }

    public void AO_Color(Color value)
    {
        AmbientOcclusion _ao = null;
        postProcess.TryGetSettings(out _ao);
        _ao.color.value = value;
    }
    
    public void AO_Ambient_Only(bool value)
    {
        AmbientOcclusion _ao = null;
        postProcess.TryGetSettings(out _ao);
        _ao.ambientOnly.value = value;
    }






    public void AutoExposure_Enable(bool value)
    {
        AutoExposure _ae = null;
        postProcess.TryGetSettings(out _ae);
        _ae.enabled.value = value;
    }

    public void AutoExposure_Filtering(Vector2 value)
    {
        AutoExposure _ae = null;
        postProcess.TryGetSettings(out _ae);
        _ae.filtering.value = value;
    }

    public void AutoExposure_MinimumEV(float value)
    {
        AutoExposure _ae = null;
        postProcess.TryGetSettings(out _ae);
        _ae.minLuminance.value = value;
    }

    public void AutoExposure_MaximumEV(float value)
    {
        AutoExposure _ae = null;
        postProcess.TryGetSettings(out _ae);
        _ae.maxLuminance.value = value;
    }

  //  public void AutoExposure_Compensation(float value)
   // {
    // AutoExposure _ae = null;
    // postProcess.TryGetSettings(out _ae);
     //  _ae.ExposureCompensation.value = value;
   //  }



 //   public void AutoExposure_Adaption_TypeEV(Types value)
    //{
   //    AutoExposure _ae = null;
    //   postProcess.TryGetSettings(out _ae);
     //  _ae.GetType.value = value;
     //}

    public void AutoExposure_Adaption_SpeedUp(float value)
    {
        AutoExposure _ae = null;
        postProcess.TryGetSettings(out _ae);
        _ae.speedUp.value = value;
    }

    public void AutoExposure_Adaption_SpeedDown(float value)
    {
        AutoExposure _ae = null;
        postProcess.TryGetSettings(out _ae);
        _ae.speedDown.value = value;
    }




    public void Bloom_Enable(bool value)
    {
        Bloom _bl = null;
        postProcess.TryGetSettings(out _bl);
        _bl.enabled.value = value;
    }

    public void Bloom_Intensity(float value)
    {
        Bloom _bl = null;
        postProcess.TryGetSettings(out _bl);
        _bl.intensity.value = value;
    }

    public void Bloom_Threshold(float value)
    {
        Bloom _bl = null;
        postProcess.TryGetSettings(out _bl);
        _bl.threshold.value = value;
    }

    public void Bloom_SoftKnee(float value)
    {
        Bloom _bl = null;
        postProcess.TryGetSettings(out _bl);
        _bl.softKnee.value = value;
    }

    public void Bloom_Clamp(float value)
    {
        Bloom _bl = null;
        postProcess.TryGetSettings(out _bl);
        _bl.clamp.value = value;
    }

    public void Bloom_Diffusion(float value)
    {
        Bloom _bl = null;
        postProcess.TryGetSettings(out _bl);
        _bl.diffusion.value = value;
    }

    public void Bloom_AnamorphicRatio(float value)
    {
        Bloom _bl = null;
        postProcess.TryGetSettings(out _bl);
        _bl.anamorphicRatio.value = value;
    }

    public void Bloom_Color(Color value)
    {
        Bloom _bl = null;
        postProcess.TryGetSettings(out _bl);
        _bl.color.value = value;
    }

    public void Bloom_FastMode(bool value)
    {
        Bloom _bl = null;
        postProcess.TryGetSettings(out _bl);
        _bl.fastMode.value = value;
    }

    public void Bloom_DirtTexture(Texture2D value)
    {
        Bloom _bl = null;
        postProcess.TryGetSettings(out _bl);
        _bl.dirtTexture.value = value;
    }

    public void Bloom_DirtIntensity(float value)
    {
        Bloom _bl = null;
        postProcess.TryGetSettings(out _bl);
        _bl.dirtIntensity.value = value;
    }




    public void ChromaticAberration_Enable(bool value)
    {
        ChromaticAberration _ca = null;
        postProcess.TryGetSettings(out _ca);
        _ca.enabled.value = value;
    }

    public void ChromaticAberration_SpectralLut(Texture2D value)
    {
        ChromaticAberration _ca = null;
        postProcess.TryGetSettings(out _ca);
        _ca.spectralLut.value = value;
    }

    public void ChromaticAberration_Intensity(float value)
    {
        ChromaticAberration _ca = null;
        postProcess.TryGetSettings(out _ca);
        _ca.intensity.value = value;
    }

    public void ChromaticAberration_FastMode(bool value)
    {
        ChromaticAberration _ca = null;
        postProcess.TryGetSettings(out _ca);
        _ca.fastMode.value = value;
    }




    public void ColorGrading_Enable(bool value)
    {
        ColorGrading _cg = null;
        postProcess.TryGetSettings(out _cg);
        _cg.enabled.value = value;
    }

    public void ColorGrading_Mode(GradingMode value)
    {
        ColorGrading _cg = null;
        postProcess.TryGetSettings(out _cg);
        _cg.gradingMode.value = value;
    }

    public void ColorGrading_Temperature(float value)
    {
        ColorGrading _cg = null;
        postProcess.TryGetSettings(out _cg);
        _cg.temperature.value = value;
    }

    public void ColorGrading_Tint(float value)
    {
        ColorGrading _cg = null;
        postProcess.TryGetSettings(out _cg);
        _cg.tint.value = value;
    }

    public void ColorGrading_PostExposureEV(float value)
    {
        ColorGrading _cg = null;
        postProcess.TryGetSettings(out _cg);
        _cg.postExposure.value = value;
    }

    public void ColorGrading_ColorFilter(Color value)
    {
        ColorGrading _cg = null;
        postProcess.TryGetSettings(out _cg);
        _cg.colorFilter.value = value;
    }

    public void ColorGrading_HueShift(float value)
    {
        ColorGrading _cg = null;
        postProcess.TryGetSettings(out _cg);
        _cg.hueShift.value = value;
    }

    public void ColorGrading_Saturation(float value)
    {
        ColorGrading _cg = null;
        postProcess.TryGetSettings(out _cg);
        _cg.saturation.value = value;
    }

    public void ColorGrading_Contrast(float value)
    {
        ColorGrading _cg = null;
        postProcess.TryGetSettings(out _cg);
        _cg.contrast.value = value;
    }

  //  public void ColorGrading_ChannelMixer(ColorGrading value)
   // {
    //   ColorGrading _cg = null;
     //   postProcess.TryGetSettings(out _cg);
     //   _cg.blueCurve.value = value;
    //}

    public void ColorGrading_ChannelMixer_Red(Spline value)
    {
        ColorGrading _cg = null;
        postProcess.TryGetSettings(out _cg);
        _cg.redCurve.value = value;
    }

    public void ColorGrading_ChannelMixer_Green(Spline value)
    {
        ColorGrading _cg = null;
        postProcess.TryGetSettings(out _cg);
        _cg.greenCurve.value = value;
    }

    public void ColorGrading_ChannelMixer_Blue(Spline value)
    {
        ColorGrading _cg = null;
        postProcess.TryGetSettings(out _cg);
        _cg.blueCurve.value = value;
    }

   // public void ColorGrading_Trackballs_EnableLift(bool value)
    //{
     //   ColorGrading _cg = null;
      //  postProcess.TryGetSettings(out _cg);
       // _cg.trackba.value = value;
    //}

    public void ColorGrading_Trackballs_Lift(Vector4 value)
    {
        ColorGrading _cg = null;
        postProcess.TryGetSettings(out _cg);
        _cg.lift.value = value;
    }

    public void ColorGrading_Trackballs_Gamme(Vector4 value)
    {
        ColorGrading _cg = null;
        postProcess.TryGetSettings(out _cg);
        _cg.gamma.value = value;
    }

    public void ColorGrading_Trackballs_Gain(Vector4 value)
    {
        ColorGrading _cg = null;
        postProcess.TryGetSettings(out _cg);
        _cg.gain.value = value;
    }




    public void DepthOfField_Enable(bool value)
    {
        DepthOfField _dof = null;
        postProcess.TryGetSettings(out _dof);
        _dof.enabled.value = value;
    }

    public void DepthOfField_FocusDistance(float value)
    {
        DepthOfField _dof = null;
        postProcess.TryGetSettings(out _dof);
        _dof.focusDistance.value = value;
    }

    public void DepthOfField_Aperture(float value)
    {
        DepthOfField _dof = null;
        postProcess.TryGetSettings(out _dof);
        _dof.aperture.value = value;
    }

   public void DepthOfField_FocalLength(float value)
    {
        DepthOfField _dof = null;
        postProcess.TryGetSettings(out _dof);
        _dof.focalLength.value = value;
    }

     public void DepthOfField_MaxBlurSize(KernelSize value)
    {
       DepthOfField _dof = null;
      postProcess.TryGetSettings(out _dof);
     _dof.kernelSize.value = value;
    }



    public void Grain_Enable(bool value)
    {
        Grain _gr = null;
        postProcess.TryGetSettings(out _gr);
        _gr.enabled.value = value;
    }

    public void Grain_Colored(bool value)
    {
        Grain _gr = null;
        postProcess.TryGetSettings(out _gr);
        _gr.colored.value = value;
    }

    public void Grain_Intensity(float value)
    {
        Grain _gr = null;
        postProcess.TryGetSettings(out _gr);
        _gr.intensity.value = value;
    }

    public void Grain_Size(float value)
    {
        Grain _gr = null;
        postProcess.TryGetSettings(out _gr);
        _gr.size.value = value;
    }

    public void Grain_LuminanceContribution(float value)
    {
        Grain _gr = null;
        postProcess.TryGetSettings(out _gr);
        _gr.lumContrib.value = value;
    }



    public void LensDistortion_Enable(bool value)
    {
        LensDistortion _ld = null;
        postProcess.TryGetSettings(out _ld);
        _ld.enabled.value = value;
    }

    public void LensDistortion_Intensity(float value)
    {
        LensDistortion _ld = null;
        postProcess.TryGetSettings(out _ld);
        _ld.intensity.value = value;
    }

    public void LensDistortion_X_Multiplayer(float value)
    {
        LensDistortion _ld = null;
        postProcess.TryGetSettings(out _ld);
        _ld.intensityX.value = value;
    }

    public void LensDistortion_Y_Multiplayer(float value)
    {
        LensDistortion _ld = null;
        postProcess.TryGetSettings(out _ld);
        _ld.intensityY.value = value;
    }

    public void LensDistortion_Center_X(float value)
    {
        LensDistortion _ld = null;
        postProcess.TryGetSettings(out _ld);
        _ld.centerX.value = value;
    }

    public void LensDistortion_Center_Y(float value)
    {
        LensDistortion _ld = null;
        postProcess.TryGetSettings(out _ld);
        _ld.centerX.value = value;
    }

    public void LensDistortion_Scale(float value)
    {
        LensDistortion _ld = null;
        postProcess.TryGetSettings(out _ld);
        _ld.scale.value = value;
    }



    public void MotionBlur_Enable(bool value)
    {
        MotionBlur _mb = null;
        postProcess.TryGetSettings(out _mb);
        _mb.enabled.value = value;
    }

    public void MotionBlur_ShutterAngle(float value)
    {
        MotionBlur _mb = null;
        postProcess.TryGetSettings(out _mb);
        _mb.shutterAngle.value = value;
    }

    public void MotionBlur_SampleCount(int value)
    {
        MotionBlur _mb = null;
        postProcess.TryGetSettings(out _mb);
        _mb.sampleCount.value = value;
    }




    public void ScreenSpaceReflection_Enable(bool value)
    {
        ScreenSpaceReflections _spr = null;
        postProcess.TryGetSettings(out _spr);
        _spr.enabled.value = value;
    }


    public void ScreenSpaceReflection_Preset(ScreenSpaceReflectionPreset value)
    {
        ScreenSpaceReflections _spr = null;
        postProcess.TryGetSettings(out _spr);
        _spr.preset.value = value;
    }


    public void ScreenSpaceReflection_MaxMarchDistance(float value)
    {
        ScreenSpaceReflections _spr = null;
        postProcess.TryGetSettings(out _spr);
        _spr.maximumMarchDistance.value = value;
    }

    public void ScreenSpaceReflection_DistanceFade(float value)
    {
        ScreenSpaceReflections _spr = null;
        postProcess.TryGetSettings(out _spr);
        _spr.distanceFade.value = value;
    }

    public void ScreenSpaceReflection_Vignette(float value)
    {
        ScreenSpaceReflections _spr = null;
        postProcess.TryGetSettings(out _spr);
        _spr.vignette.value = value;
    }




    public void Vignette_Enable(bool value)
    {
        Vignette _spr = null;
        postProcess.TryGetSettings(out _spr);
        _spr.enabled.value = value;
    }

    public void Vignette_Mode(VignetteMode value)
    {
        Vignette _spr = null;
        postProcess.TryGetSettings(out _spr);
        _spr.mode.value = value;
    }

    public void Vignette_Color(Color value)
    {
        Vignette _spr = null;
        postProcess.TryGetSettings(out _spr);
        _spr.color.value = value;
    }

    public void Vignette_Center(Vector2 value)
    {
        Vignette _spr = null;
        postProcess.TryGetSettings(out _spr);
        _spr.center.value = value;
    }

    public void Vignette_Intensity(float value)
    {
        Vignette _spr = null;
        postProcess.TryGetSettings(out _spr);
        _spr.intensity.value = value;
    }

    public void Vignette_Smoothness(float value)
    {
        Vignette _spr = null;
        postProcess.TryGetSettings(out _spr);
        _spr.smoothness.value = value;
    }

    public void Vignette_Roundness(float value)
    {
        Vignette _spr = null;
        postProcess.TryGetSettings(out _spr);
        _spr.roundness.value = value;
    }

    public void Vignette_Rounded(bool value)
    {
        Vignette _spr = null;
        postProcess.TryGetSettings(out _spr);
        _spr.rounded.value = value;
    }




}