using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkoutItemUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Toggle completeToggle;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI detailText;

    private WorkoutRoutine routine;

    public void Setup(WorkoutRoutine workout)
    {
        routine = workout;
        nameText.text = workout.name;
        detailText.text = $"{workout.sets}세트 × {workout.reps}회";

        completeToggle.isOn = workout.completed;
        completeToggle.onValueChanged.AddListener(OnToggleChanged);
    }

    private void OnToggleChanged(bool isCompleted)
    {
        routine.completed = isCompleted;
        Debug.Log($"{routine.name} 완료 상태: {isCompleted}");
    }
}
