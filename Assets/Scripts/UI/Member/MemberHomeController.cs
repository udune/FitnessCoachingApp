using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MemberHomeController : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private HeaderUI header;
    [SerializeField] private StatusGaugeUI statusGauge;
    [SerializeField] private TextMeshProUGUI statusTitle;
    [SerializeField] private TextMeshProUGUI statusDescription;
    [SerializeField] private Transform workoutListContainer;
    [SerializeField] private GameObject workoutItemPrefab;
    [SerializeField] private Button aiCoachButton;

    private List<WorkoutData> todayRoutines;

    private void Start()
    {
        aiCoachButton.onClick.AddListener(OnAICoachClicked);
        LoadTodayRoutines();
        DisplayRoutines();
        UpdateStatus();
    }

    private void UpdateStatus()
    {
        float metabolicEfficiency = 75f;
        
        if (statusGauge != null)
        {
            statusGauge.UpdateGauge(metabolicEfficiency);
        }

        if (statusTitle != null)
        {
            statusTitle.text = "현재 대사 효율";
        }
    }

    private void LoadTodayRoutines()
    {
        todayRoutines = new List<WorkoutData>
        {
            new WorkoutData("푸쉬업", 3, 15, "근력"),
            new WorkoutData("스쿼트", 3, 20, "근력"),
            new WorkoutData("플랭크", 3, 60, "근력"),
            new WorkoutData("버피", 3, 10, "유산소"),
            new WorkoutData("런지", 3, 12, "근력")
        };
    }

    private void DisplayRoutines()
    {
        foreach (var routine in todayRoutines)
        {
            GameObject item = Instantiate(workoutItemPrefab, workoutListContainer);
            WorkoutItemUI itemUI = item.GetComponent<WorkoutItemUI>();
            itemUI.Setup(routine);
        }
    }

    private void OnAICoachClicked()
    {
        Debug.Log("AI 코치 버튼 클릭됨");
    }
}
