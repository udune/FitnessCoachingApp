using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusWidget : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Image gaugeImage;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI valueText;

    [Header("Settings")]
    [SerializeField] private string statTitle = "근력";
    [SerializeField] private float currentValue = 75f;
    [SerializeField] private float maxValue = 100f;

    private void Start()
    {
        UpdateWidget();
    }

    public void SetData(string title, float value, float max)
    {
        statTitle = title;
        currentValue = value;
        maxValue = max;
        UpdateWidget();
    }

    private void UpdateWidget()
    {
        titleText.text = statTitle;
        valueText.text = $"{currentValue:F0}";
        gaugeImage.fillAmount = currentValue / maxValue;
    }
}
