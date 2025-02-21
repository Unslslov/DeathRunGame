using System.Collections;
using UnityEngine;
using Unsl;
using Zenject;

public class ActivateWeaponTutorail : MonoBehaviour
{
    private WeaponTutorail _tutorialWeapon;

    [Inject]
    public void Constructor(WeaponTutorail tutorialWeapon)
    {
        _tutorialWeapon = tutorialWeapon;
    }
    private void Start() 
    {
        var startTutor = FileSaveLoad.Load<bool>(false);

        if(startTutor == null)
            StartCoroutine(TimerActivate()); 
    }

    private IEnumerator TimerActivate()
    {
        yield return new WaitForSeconds(1f);

        _tutorialWeapon.gameObject.SetActive(true);
    }
}
