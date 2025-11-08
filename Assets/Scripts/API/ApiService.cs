using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System;

public class ApiService : MonoBehaviour
{
    public static ApiService Instance { get; private set; }

    private const string apiBaseUrl = "https://fitness-coaching-api-398791061190.asia-northeast3.run.app";

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

    public void GetRecommendations(string memberId, Action<ApiRoutinesResponse> onSuccess, Action<string> onError)
    {
        // StartCoroutine(FetchRecommendations(memberId, onSuccess, onError));

        // --- Mock 데이터 사용 (API 미구현으로 임시 활성화) ---
        Debug.Log("API가 아직 구현되지 않아 Mock 데이터를 사용합니다.");
        var mockResponse = new ApiRoutinesResponse
        {
            routines = new List<Workout>
            {
                new Workout { name = "스쿼트 (Mock)", sets = 3, reps = 15 },
                new Workout { name = "푸쉬업 (Mock)", sets = 3, reps = 12 },
                new Workout { name = "플랭크 (Mock)", sets = 3, reps = 60 },
                new Workout { name = "런지 (Mock)", sets = 3, reps = 10 },
                new Workout { name = "덤벨 컬 (Mock)", sets = 3, reps = 12 }
            }
        };
        onSuccess?.Invoke(mockResponse);
        // --- Mock 데이터 끝 ---
    }

    /*
    // 실제 API 호출 코루틴 (API 구현 후 주석 해제)
    private IEnumerator FetchRecommendations(string memberId, Action<ApiRoutinesResponse> onSuccess, Action<string> onError)
    {
        string url = $"{apiBaseUrl}/ai/routines?memberId={memberId}";
        
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                onError?.Invoke($"네트워크 에러: {webRequest.error}");
            }
            else
            {
                try
                {
                    ApiRoutinesResponse data = JsonUtility.FromJson<ApiRoutinesResponse>(webRequest.downloadHandler.text);
                    if (data == null || data.routines == null)
                    {
                        throw new Exception("JSON 데이터가 비어있거나 형식이 잘못되었습니다.");
                    }
                    onSuccess?.Invoke(data);
                }
                catch (Exception e)
                {
                    onError?.Invoke($"JSON 파싱 에러: {e.Message}. 응답 내용: {webRequest.downloadHandler.text}");
                }
            }
        }
    }
    */
}
