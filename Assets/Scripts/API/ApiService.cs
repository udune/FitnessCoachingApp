using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System;

public class ApiService : MonoBehaviour
{
    public static ApiService Instance { get; private set; }

    // private const string apiBaseUrl = "YOUR_API_ENDPOINT"; // 실제 API 주소로 변경하세요.

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GetRecommendations(string userId, Action<WorkoutRecommendation> onSuccess, Action<string> onError)
    {
        // StartCoroutine(FetchRecommendations(userId, onSuccess, onError));
        
        // --- Mock 데이터 사용 ---
        var mockData = new WorkoutRecommendation
        {
            recommendations = new List<Workout>
            {
                new Workout { name = "스쿼트", sets = 3, reps = 15 },
                new Workout { name = "푸쉬업", sets = 3, reps = 12 },
                new Workout { name = "플랭크", sets = 3, reps = 60 }, // 초 단위라고 가정
                new Workout { name = "런지", sets = 3, reps = 10 },
                new Workout { name = "덤벨 컬", sets = 3, reps = 12 }
            }
        };
        onSuccess?.Invoke(mockData);
        // --- Mock 데이터 끝 ---
    }

    /*
    // 실제 API 호출 코루틴
    private IEnumerator FetchRecommendations(string userId, Action<WorkoutRecommendation> onSuccess, Action<string> onError)
    {
        string url = $"{apiBaseUrl}/recommendations/{userId}";
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                onError?.Invoke(webRequest.error);
            }
            else
            {
                try
                {
                    WorkoutRecommendation data = JsonUtility.FromJson<WorkoutRecommendation>(webRequest.downloadHandler.text);
                    onSuccess?.Invoke(data);
                }
                catch (Exception e)
                {
                    onError?.Invoke($"JSON 파싱 에러: {e.Message}");
                }
            }
        }
    }
    */
}
