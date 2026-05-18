using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class RenderScaleAdjuster : MonoBehaviour
{
    [SerializeField] private Slider renderScaleSlider; // Ссылка на UI-бегунок
    [SerializeField] private int minRenderScale = 1; // Минимальное значение Render Scale (1)
    [SerializeField] private int maxRenderScale = 20; // Максимальное значение Render Scale (20)

    private UniversalRenderPipelineAsset urpAsset;

    private void Start()
    {
        // Получаем текущий URP Asset
        urpAsset = GraphicsSettings.currentRenderPipeline as UniversalRenderPipelineAsset;

        if (urpAsset == null)
        {
            Debug.LogError("Current Render Pipeline is not Universal Render Pipeline.");
            return;
        }

        if (renderScaleSlider == null)
        {
            Debug.LogError("Render Scale Slider is not assigned.");
            return;
        }

        // Настраиваем бегунок
        renderScaleSlider.minValue = minRenderScale;
        renderScaleSlider.maxValue = maxRenderScale;
        renderScaleSlider.value = Mathf.RoundToInt(urpAsset.renderScale * 10); // Преобразуем renderScale в диапазон 1-20

        // Подписываемся на изменение значения бегунка
        renderScaleSlider.onValueChanged.AddListener(OnRenderScaleChanged);
    }

    private void OnRenderScaleChanged(float value)
    {
        if (urpAsset != null)
        {
            urpAsset.renderScale = value / 10f; // Преобразуем значение обратно в диапазон 0.1-2.0
            Debug.Log($"Render Scale updated to: {value / 10f}");
        }
    }

    private void OnDestroy()
    {
        // Отписываемся от события изменения значения бегунка
        if (renderScaleSlider != null)
        {
            renderScaleSlider.onValueChanged.RemoveListener(OnRenderScaleChanged);
        }
    }
}