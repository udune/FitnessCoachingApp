using UnityEngine;

public class WorkoutlistController : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Transform listContainer;
    [SerializeField] private GameObject workoutItemPrefab;

    private WorkoutData[] workouts;

    private void Start()
    {
        LoadMockData();
        RefreshList();
    }

    private void LoadMockData()
    {
        workouts = new WorkoutData[]
        {
            new WorkoutData("바벨 스쿼트", 4, 12, "근력"),
            new WorkoutData("덤벨 벤치프레스", 4, 10, "근력"),
            new WorkoutData("데드리프트", 3, 8, "근력"),
            new WorkoutData("러닝머신", 1, 20, "유산소"),
            new WorkoutData("전신 스트레칭", 1, 10, "스트레칭")
        };
    }

    public void RefreshList()
    {
        ClearList();
        foreach (var workout in workouts)
        {
            CreateItem(workout);
        }
    }

    private void CreateItem(WorkoutData data)
    {
        GameObject item = Instantiate(workoutItemPrefab, listContainer);
        WorkoutItemUI itemScript = item.GetComponent<WorkoutItemUI>();
        itemScript.Setup(data);
    }

    private void ClearList()
    {
        foreach (Transform child in listContainer)
        {
            Destroy(child.gameObject);
        }
    }

    public int GetCompletedCount()
    {
        int count = 0;
        foreach (var w in workouts)
        {
            if (w.completed)
            {
                count++;
            }
        }
        return count;
    }

    public int GetTotalCount()
    {
        return workouts.Length;
    }
}
