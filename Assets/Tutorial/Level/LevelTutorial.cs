using UnityEngine;
using UnityEngine.UI;

public class LevelTutorial : MonoBehaviour
{
    [SerializeField] private Image _level;
    [SerializeField] private Animator _arrowAnim;

    private Animator _anim;
    private Transform _parentJoystick;

    private void Start() 
    {
        _arrowAnim.SetTrigger("Menu");
        
        _parentJoystick = _level.transform.parent;

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
        _level.transform.SetParent(transform);
    }

    private void ResetParentForJoystick()
    {
        _level.transform.SetParent(_parentJoystick);
        _level.transform.SetAsFirstSibling();
    }
}
