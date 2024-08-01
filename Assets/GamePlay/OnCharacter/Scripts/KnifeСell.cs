using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KnifeСell : MonoBehaviour, IPointerClickHandler, IPointerDownHandler //, IPointerUpHandler
{
    [SerializeField] private GameObject _weaponPrefab;
    [SerializeField] private Movement _playerMovement; 
    public float Speed {get; private set;}
    public float JumpForce {get; private set;}
    public float Gravity {get; private set;}
    public Transform PrefabWeaponOnScene;
    
    private GameObject _preSelectedIcon;
    private GameObject _SelectedIcon;

    public void Render(KnifeAttribute knifeAttribute, Transform place, Movement playerMovement)
    {
        Speed = knifeAttribute.Speed;
        JumpForce = knifeAttribute.JumpForce;
        Gravity = knifeAttribute.Gravity;

        transform.GetChild(3).gameObject.GetComponent<Image>().sprite = knifeAttribute.ImageIcon;
        _weaponPrefab = knifeAttribute.WeaponPrefab;

        _playerMovement = playerMovement;
        
        PrefabWeaponOnScene = place;

        _SelectedIcon = transform.GetChild(2).gameObject;
        _preSelectedIcon = transform.GetChild(1).gameObject;
    }

    //  Execution order : PointerDown -> PointerUp -> PointerClickt
    public void OnPointerDown(PointerEventData eventData)
    {
        _preSelectedIcon.SetActive(true);
    }

     public void OnPointerClick(PointerEventData eventData)
    {
        // TODO : CLEAR CHILD OBJECTS IN TRANSFORM
        _SelectedIcon.SetActive(true);

        var cell = Instantiate(_weaponPrefab, PrefabWeaponOnScene);
        cell.transform.localPosition = new Vector3(0,0,0);

        _playerMovement.SetMovementSettings(this);
    }

    // public void OnPointerUp(PointerEventData eventData)
    // {
    //     // TODO : CLEAR CHILD OBJECTS IN TRANSFORM
    //     _SelectedIcon.SetActive(true);

    //     var cell = Instantiate(_weaponPrefab, PrefabWeaponOnScene);
    //     cell.transform.localPosition = new Vector3(0,0,0);

    //     _playerMovement.SetMovementSettings(this);
    // }

    // public void OnPointerClick(PointerEventData eventData)
    // {
    //     _SelectedIcon.SetActive(false);
    //     _preSelectedIcon.SetActive(false);
    // }
}
