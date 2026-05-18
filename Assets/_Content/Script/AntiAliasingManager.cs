using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AntiAliasingManager : MonoBehaviour
{
    private UniversalAdditionalCameraData cameraData;

    private void Awake()
    {
        // Получаем данные камеры
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            mainCamera.TryGetComponent(out cameraData);
        }
    }

    /// <summary>
    /// Устанавливает режим анти-алиасинга.
    /// </summary>
    /// <param name="mode">0 = None, 1 = FXAA, 2 = SMAA.</param>
    public void SetAntiAliasing(int mode)
    {
        if (cameraData == null) return;

        switch (mode)
        {
            case 0: // None
                cameraData.antialiasing = AntialiasingMode.None;
                break;

            case 1: // FXAA
                cameraData.antialiasing = AntialiasingMode.FastApproximateAntialiasing;
                break;

            case 2: // SMAA
                cameraData.antialiasing = AntialiasingMode.SubpixelMorphologicalAntiAliasing;
                cameraData.antialiasingQuality = AntialiasingQuality.High; // Можно изменить на Low или Medium
                break;

            default:
                // Ничего не делаем, если передано некорректное значение
                break;
        }
    }
}