using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusGaugeUI : MonoBehaviour
{
    public Image fillImage;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    
    [Range(0, 100)] 
    public float value;
    
    private void Start()
    {
        UpdateGauge(75f); // 초기 값 설정
    }
    
    public void UpdateGauge(float newValue)
    {
        StartCoroutine(AnimateGauge(value, newValue));
    }

    IEnumerator AnimateGauge(float from, float to)
    {
        float elapsed = 0f;
        float duration = 0.5f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            value = Mathf.Lerp(from, to, elapsed / duration);
            yield return null;
        }

        value = to;
    }

    Color GetColorByValue(float value)
    {
        return Color.Lerp(Color.red, Color.green, value / 100f);
    }
    
    string GetStatusText(float value)
    {
        if (value >= 80f)
        {
            return "좋음";
        }

        if (value >= 60f)
        {
            return "보통";
        }

        if (value >= 40f)
        {
            return "주의";
        }
        
        return "나쁨";
    }
}
