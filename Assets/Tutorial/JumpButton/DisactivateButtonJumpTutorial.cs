using UnityEngine;
using UnityEngine.EventSystems;
using Unsl;
using Zenject;

public class DisactivateButtonJumpTutorial : MonoBehaviour, IPointerDownHandler
{
    private TutorialButtonJump _tutorialButtonAttack;

    [Inject]
    public void Constructor(TutorialButtonJump tutorialButtonAttack)
    {
        _tutorialButtonAttack = tutorialButtonAttack;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        FileSaveLoad.Save(true, false);

        _tutorialButtonAttack.TurnOffTutor();
    }
}
