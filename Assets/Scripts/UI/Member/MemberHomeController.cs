using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemberHomeController : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private HeaderUI header;
    [SerializeField] private Transform workoutListContainer;
    [SerializeField] private GameObject workoutItemPrefab;
    [SerializeField] private Button aiCoachButton;

    private List<WorkoutRoutine> todayRoutines;

    private void Start()
    {
        aiCoachButton.onClick.AddListener(OnAICoachClicked);
        LoadTodayRoutines();
        DisplayRoutines();
    }

    private void LoadTodayRoutines()
    {
        todayRoutines = new List<WorkoutRoutine>
        {
            new WorkoutRoutine { id = 1, name = "푸쉬업", sets = 3, reps = 15 },
            new WorkoutRoutine { id = 2, name = "스쿼트", sets = 3, reps = 20 },
            new WorkoutRoutine { id = 3, name = "플랭크", sets = 3, reps = 60 },
            new WorkoutRoutine { id = 4, name = "버피", sets = 3, reps = 10 },
            new WorkoutRoutine { id = 5, name = "런지", sets = 3, reps = 12 }
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
