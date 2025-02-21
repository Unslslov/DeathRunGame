using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WeaponTutorail : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Animator _arrowAnim;

    private Transform _parentJoystick;

    private void Start() 
    {
        _arrowAnim.SetTrigger("Up");
        
        _parentJoystick = _button.transform.parent;

        SetParentForJoystick();
    }

    public void TurnOffTutor()
    {
        Debug.Log(this.gameObject.activeInHierarchy == true);
        Debug.Log(gameObject.activeInHierarchy == true);

        if(gameObject.activeInHierarchy == true)
        {
            ResetParentForJoystick();

            Destroy(gameObject);
        }
    }
    // private IEnumerator Destroy()
    // {
    //     yield return  new WaitForSeconds(0.5f);

    //     Destroy(gameObject);
    // }

    private void SetParentForJoystick()
    {
        _button.transform.SetParent(transform);
        _button.transform.SetSiblingIndex(transform.childCount - 2);
    }

    private void ResetParentForJoystick()
    {
        _button.transform.SetParent(_parentJoystick);
    }
}
