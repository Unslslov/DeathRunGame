using System.Collections;
using Player;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KnifeСell : MonoBehaviour, IPointerClickHandler //, IPointerDownHandler, IPointerUpHandler
{
    [Header("Objects In The Prefab")]
    [SerializeField] private GameObject _SelectedIcon;
    [SerializeField] private Image _icon; 
    
    [Header("Text Scales")]
    [SerializeField] private TextMeshProUGUI _scaleSpeed;
    [SerializeField] private TextMeshProUGUI _scaleGravity;

    [Header("ObjectsFromDistributor")]
    [SerializeField] private GameObject _weaponPrefab;
    [SerializeField] private Movement _playerMovement;
    public Transform PrefabWeaponOnScene;

    public float Speed {get; private set;}
    public float JumpForce {get; private set;}
    public float Gravity {get; private set;}

    public void Render(KnifeAttribute knifeAttribute, Transform place, Movement playerMovement)
    {
        Speed = knifeAttribute.Speed;
        JumpForce = knifeAttribute.JumpForce;
        Gravity = knifeAttribute.Gravity;

        _icon.sprite = knifeAttribute.ImageIcon;
        _weaponPrefab = knifeAttribute.WeaponPrefab;

        _playerMovement = playerMovement;
        
        PrefabWeaponOnScene = place;

        _scaleSpeed.text = ((int)Speed).ToString();
        _scaleGravity.text = Mathf.Abs((int)Gravity).ToString();
    }

    //  Execution order : PointerDown -> PointerUp -> PointerClick
     public void OnPointerClick(PointerEventData eventData)
    {
        // TODO : CLEAR CHILD OBJECTS IN TRANSFORM
        _SelectedIcon.SetActive(true);

        if(PrefabWeaponOnScene.childCount == 0)
        {
            var cell = Instantiate(_weaponPrefab, PrefabWeaponOnScene);
            cell.transform.localPosition = new Vector3(0,0,0);
        }
        else 
        {
            Destroy(PrefabWeaponOnScene.GetChild(0).gameObject);

            var cell = Instantiate(_weaponPrefab, PrefabWeaponOnScene);
            cell.transform.localPosition = new Vector3(0,0,0);
        }

        _playerMovement.SetMovementSettings(this);
        
        StartCoroutine(DisableSelectedIcon());
    }

    private IEnumerator DisableSelectedIcon()
    {
        yield return  new WaitForSeconds(0.15f);

        _SelectedIcon.SetActive(false);
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
