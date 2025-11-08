using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkoutItemUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Toggle completeToggle;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI detailText;

    [Header("Colors")]
    [SerializeField] private Color normalColor = new Color(1f, 1f, 1f, 1f);
    [SerializeField] private Color completedColor = new Color(0.85f, 0.95f, 0.85f, 1f);
    
    private WorkoutData data;
    private Image backgroundImage;
    
    private void Awake()
    {
        if (completeToggle != null)
        {
            backgroundImage = completeToggle.transform.Find("Background")?.GetComponent<Image>();
        }
    }

    public void Setup(WorkoutData workout)
    {
        data = workout;
        nameText.text = workout.name;
        detailText.text = $"{workout.sets}세트 × {workout.reps}회 · {workout.exerciseType}";

        completeToggle.isOn = workout.completed;
        UpdateBackground();

        completeToggle.onValueChanged.AddListener(OnToggleChanged);
    }

    private void OnToggleChanged(bool isCompleted)
    {
        if (data != null)
        {
            data.completed = isCompleted;
            UpdateBackground();
            Debug.Log($"{data.name} 완료: {isCompleted}");
        }
    }
    
    private void UpdateBackground()
    {
        if (backgroundImage != null)
        {
            backgroundImage.color = data.completed ? completedColor : normalColor;
        }
    }

    private void OnDestroy()
    {
        if (completeToggle != null)
        {
            completeToggle.onValueChanged.RemoveListener(OnToggleChanged);
        }
    }
}
