using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelSelection : MonoBehaviour
{
    [SerializeField] private Button _level;
    [SerializeField] private Transform _stars;

    [HideInInspector] public int CurrentLevel;
    [HideInInspector] public int CountStars;

    private AudioSource _audioSource;
    private AudioClip  _clip;

    private void OnValidate() 
    {
        _level ??= GetComponent<Button>();
        _stars ??= transform.GetChild(0).GetChild(1).GetComponent<Transform>();
    }
    
    public void Initialized(AudioSource audioSource, AudioClip clip) 
    {
        _audioSource = audioSource;
        _clip = clip;
    

        if(LevelInfo.CountStarsOnLevels.Count != 0)
            CountStars = LevelInfo.CountStarsOnLevels[CurrentLevel - 1]; // Because CurrentLevel = i + 1; I do this for SceneManager.LoadScene

        Debug.Log(CountStars + " " + CurrentLevel + " " + (CurrentLevel - 1));

        for(int i=0; i < CountStars; i++)
        {
            _stars.GetChild(i).gameObject.SetActive(true);
        }
    }

    private void Start() 
    {
        _level.onClick.AddListener(ChangeLevel);
    }

    private void ChangeLevel()
    {
        if(_audioSource != null)
        {
            _audioSource.PlayOneShot(_clip);
        }

        LevelInfo.NumberLevel = CurrentLevel - 1;

        SceneManager.LoadScene(CurrentLevel);
    }
    
    private void OnDestroy()
    {
        _level.onClick.RemoveListener(ChangeLevel);
    }

}
