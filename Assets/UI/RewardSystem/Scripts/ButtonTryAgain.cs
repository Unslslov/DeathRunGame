using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonTryAgain : MonoBehaviour
{
    [SerializeField] private Button _tryAgain;

    private void OnValidate() 
    {
        _tryAgain ??= GetComponent<Button>();
    }
    
    private void OnEnable() 
    {
        _tryAgain.onClick.AddListener(OnTryAgainClick);
    }

    private void OnTryAgainClick()
    {
        SceneManager.LoadScene(LevelInfo.NumberLevel + 1);
    }

    private void OnDisable() 
    {
        _tryAgain.onClick.RemoveListener(OnTryAgainClick);
    }
}
