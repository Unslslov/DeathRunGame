
using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BuyButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private ShowPlayerMoney _showPlayerMoney;

    public ShopCell shopCell;
    public event Action<string> OnBuyEvent;
    public int Cost;

    private void OnValidate() 
    {
        _button ??= GetComponent<Button>();    
    }

    private void OnEnable() 
    {
        _button.onClick.AddListener(SaveCell);
        _button.onClick.AddListener(Buy); 
    }

    private void Buy()
    {
        shopCell.DestroyCoinAfterBuy();
        shopCell.isCanBuy = false;
    }

    private void SaveCell()
    {
        OnBuyEvent?.Invoke(shopCell.Name);

        _showPlayerMoney.ChangeMoney(Cost, false);
    }

    private void OnDisable() 
    {
        _button.onClick.RemoveListener(SaveCell);
        _button.onClick.RemoveListener(Buy); 
    }
}
