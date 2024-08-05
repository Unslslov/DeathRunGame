using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class QuitGame : MonoBehaviour
{
    [SerializeField] private Button _exitButton;

    private void OnValidate() 
    {
        _exitButton ??= GetComponent<Button>();    
    }

    void Start()
    {
        _exitButton.onClick.AddListener(ExitGame);
    }

    private void ExitGame()
    {
        _exitButton.onClick.RemoveListener(ExitGame);
        Application.Quit();
    }
}
