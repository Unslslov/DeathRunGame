using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TutorialButtonJump : MonoBehaviour
{
    [SerializeField] private Image _buttonJump;
    [SerializeField] private Animator _arrowAnim;

    private Transform _parentJoystick;

    private void Start() 
    {
        _arrowAnim.enabled = true;
        _arrowAnim.SetTrigger("Right");

        _parentJoystick = _buttonJump.transform.parent;

        SetParentForJoystick();
    }

    public void TurnOffTutor()
    {
        if(this.gameObject.activeInHierarchy == true)
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
        _buttonJump.transform.SetParent(transform);
        _buttonJump.transform.SetSiblingIndex(transform.childCount - 2);
    }

    private void ResetParentForJoystick()
    {
        _buttonJump.transform.SetParent(_parentJoystick);
        _buttonJump.transform.SetAsFirstSibling();
    }
}
