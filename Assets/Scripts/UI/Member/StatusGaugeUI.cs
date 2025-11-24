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
        UpdateGauge(75f);
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
}
