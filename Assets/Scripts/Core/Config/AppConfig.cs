using UnityEngine;

[CreateAssetMenu(fileName = "AppConfig", menuName = "Scriptable Objects/AppConfig")]
public class AppConfig : ScriptableObject
{
    private static AppConfig instance;

    public static AppConfig Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<AppConfig>("Config/AppSettings");
            }

            return instance;
        }
    }
    
    [Header("Api Settings")]
    public string apiBaseUrl = "http://localhost:3000/api";
    
    [Header("App Settings")]
    public bool IsDevelopment = true;
}
