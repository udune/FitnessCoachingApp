using UnityEngine;
using UnityEngine.UI;

public class AICoachFAB : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad = "AICoach";

    private Button fabButton;

    void Start()
    {
        fabButton = GetComponent<Button>();
        if (fabButton != null)
        {
            fabButton.onClick.AddListener(OnClick);
        }
        else
        {
            Debug.LogError("AICoachFAB script requires a Button component on the same GameObject.");
        }
    }

    void OnClick()
    {
        if (SceneController.Instance != null)
        {
            SceneController.Instance.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("SceneController instance not found.");
        }
    }

    void OnDestroy()
    {
        if (fabButton != null)
        {
            fabButton.onClick.RemoveListener(OnClick);
        }
    }
}
