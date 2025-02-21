using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Button))]
public class RestartLevel : MonoBehaviour
{
    [SerializeField] private Button button;

    private void OnValidate() 
    {
        button = GetComponent<Button>();
    }
    
    private void OnEnable() 
    {
        button.onClick.AddListener(RestartLevelButtonClicked);
    }

    private  void RestartLevelButtonClicked()
    {
        Time.timeScale = 1f;
    }

    private void OnDisable() 
    {
        button.onClick.RemoveListener(RestartLevelButtonClicked);
    }

}
