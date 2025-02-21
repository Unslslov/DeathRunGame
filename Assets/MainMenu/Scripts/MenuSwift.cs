using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MenuSwift : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void OnValidate() 
    {
        _button ??= GetComponent<Button>();
    }

    private void OnEnable() 
    {
        _button.onClick.AddListener(SwitchOnMainMenu);
    }

    private void SwitchOnMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void OnDisable() 
    {
        _button.onClick.RemoveListener(SwitchOnMainMenu); 
    }
}
