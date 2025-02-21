using System.Collections;
using UnityEngine;
using Unsl;
using Zenject;

public class ActivateJumpButtonTutorial : MonoBehaviour
{
    private TutorialButtonJump _tutorialButtonAttack;

    [Inject]
    public void Constructor(TutorialButtonJump tutorialButtonAttack)
    {
        _tutorialButtonAttack = tutorialButtonAttack;
    }

    public void StartTutor() 
    {
       var startTutor = FileSaveLoad.Load<bool>(false);

        if(startTutor == null)
            StartCoroutine(TimerActivate());       
    }

    private IEnumerator TimerActivate()
    {
        yield return new WaitForSeconds(2f);

        _tutorialButtonAttack.gameObject.SetActive(true);
    }
}
