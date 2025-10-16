using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace Network
{
    public class ApiClient : MonoBehaviour
    {
        public static ApiClient Instance { get; private set; }
        private string baseUrl;
        
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                baseUrl = AppConfig.Instance.apiBaseUrl;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public IEnumerator Get(string endpoint, Action<string> onSuccess, Action<string> onError)
        {
            using UnityWebRequest request = UnityWebRequest.Get(baseUrl + endpoint);
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                onSuccess?.Invoke(request.downloadHandler.text);
            }
            else
            {
                onError?.Invoke(request.error);
            }
        }

        public IEnumerator Post(string endpoint, Action<string> onSuccess, Action<string> onError)
        {
            using UnityWebRequest request = new UnityWebRequest(baseUrl + endpoint, "POST");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(request.downloadHandler.text);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            
            yield return request.SendWebRequest();
            
            if (request.result == UnityWebRequest.Result.Success)
            {
                onSuccess?.Invoke(request.downloadHandler.text);
            }
            else
            {
                onError?.Invoke(request.error);
            }
        }
    }
}