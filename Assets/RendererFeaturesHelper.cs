using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RendererFeaturesHelper : MonoBehaviour
{
    [SerializeField] private UniversalRendererData feature;

    /// <summary>
    /// Включает или отключает первый Renderer Feature в Universal Renderer Data.
    /// </summary>
    /// <param name="isActive">Флаг активации</param>
    public void RetroEffectToggle(bool isActive)
    {
        // Проверяем, что feature не null
        if (feature == null)
        {
            Debug.LogError("UniversalRendererData не назначен в инспекторе.");
            return;
        }

        // Проверяем, что есть хотя бы один элемент в rendererFeatures
        if (feature.rendererFeatures == null || feature.rendererFeatures.Count == 0)
        {
            Debug.LogError("Список rendererFeatures пуст или отсутствует.");
            return;
        }

        // Включаем или отключаем первый Renderer Feature
        feature.rendererFeatures[0].SetActive(isActive);
        Debug.Log($"Renderer Feature '{feature.rendererFeatures[0].name}' " +
                  $"{(isActive ? "включен" : "отключен")}.");
    }
}
