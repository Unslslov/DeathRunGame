using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class DisactivateWeaponTutorail : MonoBehaviour, IPointerClickHandler
{
    private WeaponTutorail _tutorialWeapon;

    [Inject]
    public void Constructor(WeaponTutorail tutorialWeapon)
    {
        _tutorialWeapon = tutorialWeapon;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _tutorialWeapon.TurnOffTutor();
    }

    // public void OnPointerDown(PointerEventData eventData)
    // {  
    //     _tutorialWeapon.TurnOffTutor();
    // }

    // public void OnPointerUp(PointerEventData eventData)
    // {
    //     _tutorialWeapon.TurnOffTutor();
    // }
}
