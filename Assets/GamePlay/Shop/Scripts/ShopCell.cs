using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopCell : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private TextMeshProUGUI _gravityText;
    [SerializeField] private TextMeshProUGUI _speedText; 
    [SerializeField] private float _gravity;
    [SerializeField] private float _speed;
    [SerializeField] private int _cost;

    [Header("Messages")]
    [SerializeField] private BuyMessage _buyMessageForPlayer;
    [SerializeField] private GameObject _lackOfMoneyMessage;

    [Header("Coins")]
    [SerializeField] private GameObject _coin;
    [SerializeField] private TextMeshProUGUI _costText;

    public bool isCanBuy;
    public event Action<int, ShopCell> CurrentActiveShopCellEvent;
    public string Name {get; private set;}

    private AudioSource _audioSource;
    private AudioClip _clip;

    public void OnPointerDown(PointerEventData eventData)
    {
        _audioSource.PlayOneShot(_clip);

        if(isCanBuy)
        {
            if(Money.coins >= _cost)
            {
                _buyMessageForPlayer._knife = Name;
                _buyMessageForPlayer.transform.parent.gameObject.SetActive(true);
    
                CurrentActiveShopCellEvent?.Invoke(_cost, this);
            }
            else
            {
                _lackOfMoneyMessage.SetActive(true);
            }
        }
    }

    public void Render(KnifeAttribute knifeAttribute, BuyMessage buyMessageForPlayer, GameObject lackOfMoneyMessage, List<string> nameKnives)
    {
        _speed = knifeAttribute.Speed;
        _gravity = Mathf.Abs(knifeAttribute.Gravity);

        Name = knifeAttribute.Name;

        if(nameKnives.Any(knife => knife.Equals(Name)))
        {
            DestroyCoinAfterBuy();

            isCanBuy = false;
        }
        else 
        {
            _cost = knifeAttribute.Cost;
            isCanBuy = true;
        }
        
        _buyMessageForPlayer = buyMessageForPlayer;
        _lackOfMoneyMessage = lackOfMoneyMessage;

        transform.GetChild(3).gameObject.GetComponent<Image>().sprite = knifeAttribute.ImageIcon;

        _gravityText.text = ((int)_gravity).ToString();
        _speedText.text = ((int)_speed).ToString(); 
        _costText.text = ((int)_cost).ToString(); 
    }

    public void InitializedSound(AudioSource audioSource, AudioClip clip)
    {
        _audioSource = audioSource;
        _clip = clip;
    }

    public void DestroyCoinAfterBuy()
    {
        Destroy(_coin);
        Destroy(_costText.gameObject);
    }
}
