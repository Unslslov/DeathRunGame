using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class DisactivateJoystickTutorial : MonoBehaviour, IPointerDownHandler
{
    private TutorialJoystick _tutorialJoystick;
    private ActivateJumpButtonTutorial  _activateJumpButtonTutorial;

    [Inject]
    public void Constructor(TutorialJoystick tutorialJoystick, ActivateJumpButtonTutorial activateJumpButtonTutorial)
    {
        _tutorialJoystick = tutorialJoystick;
        _activateJumpButtonTutorial = activateJumpButtonTutorial;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _activateJumpButtonTutorial.StartTutor();
        
        _tutorialJoystick.TurnOffTutor();
    }
}
