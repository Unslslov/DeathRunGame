using System.Collections;
using UnityEngine;

public class TutorialJoystick : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Animator _arrowAnim;

    private Animator _anim;
    private Transform _parentJoystick;

    private void Start() 
    {
        _anim = _joystick.GetComponent<Animator>();
        _anim.enabled = true;
        _arrowAnim.SetTrigger("Left");
        
        _parentJoystick = _joystick.transform.parent;

        SetParentForJoystick();
    }

    public void TurnOffTutor()
    {
        if(this.gameObject.activeInHierarchy == true)
        {
            ResetParentForJoystick();

            Destroy();
        }
    }
    private void Destroy()
    {
        Destroy(_anim);
        Destroy(gameObject);
    }

    private void SetParentForJoystick()
    {
        _joystick.transform.SetParent(transform);
        _joystick.transform.SetSiblingIndex(transform.childCount - 2);
    }

    private void ResetParentForJoystick()
    {
        _joystick.transform.SetParent(_parentJoystick);
        _joystick.transform.SetAsFirstSibling();
    }
}
