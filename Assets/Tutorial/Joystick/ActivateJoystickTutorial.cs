using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using Unsl;
using Zenject;

public class ActivateJoystickTutorial : MonoBehaviour, IPointerUpHandler
{
    private TutorialJoystick _tutorialJoystick;

    [Inject]
    public void Constructor(TutorialJoystick tutorialJoystick)
    {
        _tutorialJoystick = tutorialJoystick;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StartTutor();
    }

    private void StartTutor()
    {
        var startTutor = FileSaveLoad.Load<bool>(false);

        if(startTutor == null)
            TimerActivate();   
    }

    private void TimerActivate()
    {
        _tutorialJoystick.gameObject.SetActive(true);
    }
}


