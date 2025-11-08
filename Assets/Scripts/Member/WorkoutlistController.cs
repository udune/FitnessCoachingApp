using UnityEngine;
using TMPro;
using System.Linq;

public class WorkoutlistController : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Transform listContainer;
    [SerializeField] private GameObject workoutItemPrefab;
    [SerializeField] private TextMeshProUGUI loadingText;
    [SerializeField] private TextMeshProUGUI errorText;

    private WorkoutData[] workouts;

    private void Start()
    {
        LoadRecommendations();
    }

    private void LoadRecommendations()
    {
        ShowLoading();
        
        // Swagger API에 따라 memberId를 전달합니다. "1"은 테스트용 ID입니다.
        string memberId = "1"; 
        ApiService.Instance.GetRecommendations(memberId,
            (apiResponse) => {
                // ApiService의 Workout 리스트(apiResponse.routines)를 UI용 WorkoutData 리스트로 변환
                workouts = apiResponse.routines.Select(w => new WorkoutData(w.name, w.sets, w.reps, "AI 추천")).ToArray();
                RefreshList();
                ShowList();
            },
            (error) => {
                ShowError(error);
            }
        );
    }

    public void RefreshList()
    {
        ClearList();
        if (workouts == null) return;

        foreach (var workout in workouts)
        {
            CreateItem(workout);
        }
    }

    private void CreateItem(WorkoutData data)
    {
        GameObject item = Instantiate(workoutItemPrefab, listContainer);
        WorkoutItemUI itemScript = item.GetComponent<WorkoutItemUI>();
        if (itemScript != null)
        {
            itemScript.Setup(data);
        }
    }

    private void ClearList()
    {
        foreach (Transform child in listContainer)
        {
            Destroy(child.gameObject);
        }
    }

    private void ShowLoading()
    {
        if (loadingText) loadingText.gameObject.SetActive(true);
        if (errorText) errorText.gameObject.SetActive(false);
        listContainer.gameObject.SetActive(false);
    }

    private void ShowList()
    {
        if (loadingText) loadingText.gameObject.SetActive(false);
        if (errorText) errorText.gameObject.SetActive(false);
        listContainer.gameObject.SetActive(true);
    }

    private void ShowError(string message)
    {
        if (loadingText) loadingText.gameObject.SetActive(false);
        if (errorText)
        {
            errorText.gameObject.SetActive(true);
            errorText.text = $"데이터를 불러오지 못했습니다: {message}";
        }
        listContainer.gameObject.SetActive(false);
    }

    public int GetCompletedCount()
    {
        if (workouts == null) return 0;
        return workouts.Count(w => w.completed);
    }

    public int GetTotalCount()
    {
        if (workouts == null) return 0;
        return workouts.Length;
    }
}
