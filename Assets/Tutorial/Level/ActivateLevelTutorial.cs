using System.Collections;
using UnityEngine;
using Unsl;

public class ActivateLevelTutorial : MonoBehaviour
{
    [SerializeField] private LevelTutorial _tutorialLevelTutor;

    private void Awake() 
    {
        var startTutor = FileSaveLoad.Load<bool>(false);

        if(startTutor == null)
            StartCoroutine(TimerActivate());    
    }

    private IEnumerator TimerActivate()
    {
        yield return new WaitForSeconds(0.4f);

        _tutorialLevelTutor.gameObject.SetActive(true);
    }
}
