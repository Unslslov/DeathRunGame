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
    [SerializeField] private float _cost;

    [SerializeField] private BuyMessage _buyMessageForPlayer;
    [SerializeField] private GameObject _lackOfMoneyMessage;

    [Header("Coins")]
    [SerializeField] private GameObject _coin;
    [SerializeField] private TextMeshProUGUI _costText;

    private bool isCanBuy;
    // public event Action Event;

    public string Name {get; private set;}

    public void OnPointerDown(PointerEventData eventData)
    {
        if(isCanBuy)
        {
            if(Money.coins >= _cost)
            {
                _buyMessageForPlayer._knife = Name;
                _buyMessageForPlayer.transform.parent.gameObject.SetActive(true); 
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
        _gravity = knifeAttribute.Gravity;

        Name = knifeAttribute.Name;

        if(nameKnives.Any(knife => knife.Equals(Name)))
        {
            _cost = knifeAttribute.Cost;
            isCanBuy = true;
        }
        else 
        {
            Destroy(_coin);
            Destroy(_costText.gameObject);
            isCanBuy = false;
        }
        

        _buyMessageForPlayer = buyMessageForPlayer;
        _lackOfMoneyMessage = lackOfMoneyMessage;

        transform.GetChild(3).gameObject.GetComponent<Image>().sprite = knifeAttribute.ImageIcon;

        _gravityText.text = ((int)_gravity).ToString();
        _speedText.text = ((int)_speed).ToString(); 
        _costText.text = ((int)_cost).ToString(); 
    }
}
