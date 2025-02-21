using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonMainMenu : MonoBehaviour
{
    [SerializeField] private Button _mainMenu;

    private void OnValidate() 
    {
        _mainMenu ??= GetComponent<Button>();
    }

    private void OnEnable() 
    {
        _mainMenu.onClick.AddListener(OnMainMenuClick);
    }

    private void OnMainMenuClick()
    {
        SceneManager.LoadScene(0);
    }

    private void OnDisable() 
    {
        _mainMenu.onClick.RemoveListener(OnMainMenuClick);
    }


}
