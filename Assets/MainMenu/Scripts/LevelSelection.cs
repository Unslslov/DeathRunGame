using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelSelection : MonoBehaviour
{
    [SerializeField] private Button _level;
    public int CurrentLevel;

    private void OnValidate() 
    {
        _level ??= GetComponent<Button>();
    }
    
    private void Start() 
    {
        _level.onClick.AddListener(ChangeLevel);
    }

    private void ChangeLevel()
    {
        SceneManager.LoadScene(CurrentLevel);
    }
    
    private void OnDestroy()
    {
        _level.onClick.RemoveListener(ChangeLevel);
    }

}
