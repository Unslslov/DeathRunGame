using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScrollLevels : MonoBehaviour, IScrollLevels
{
    [SerializeField] private Transform[] _activelevels;
    [SerializeField] private Transform[] _disactivelevels;
    [SerializeField] private Button _button;
    private UnityAction onMainMenuClickAction;

    private void OnValidate() 
    {
        _button ??= GetComponent<Button>();
    }

    private void Awake() 
    {
        onMainMenuClickAction = () => Scrolling(_activelevels, _disactivelevels);
    }

    private void OnEnable() 
    {
        _button.onClick.AddListener(onMainMenuClickAction);
    }

    public void Scrolling(Transform[] activelevels, Transform[] disactivelevels)
    {
        Debug.Log("111");

        if(!activelevels[0].gameObject.activeInHierarchy)
        {
            foreach(var level in activelevels)
            {
                level.gameObject.SetActive(true);
            }

            foreach(var level in disactivelevels)
            {
                level.gameObject.SetActive(false);
            }
        }  
    }

    private void OnDisable() 
    {
        _button.onClick.AddListener(onMainMenuClickAction);
    }
}
