using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeaderUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Button notificationButton;

    private void Start()
    {
        notificationButton.onClick.AddListener(OnNotificationClicked);
        UpdateHeader();
    }

    public void UpdateHeader()
    {
        nameText.text = "홍길동";
        levelText.text = "레벨 3";
    }
    
    private void OnNotificationClicked()
    {
        Debug.Log("Notification button clicked");
    }
}
