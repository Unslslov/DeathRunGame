using System;
using TMPro;
using UnityEngine;
using Unsl;

public class ShowPlayerMoney : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textField;

    private void OnEnable() 
    {
        Show();
    }

    private void Show()
    {
        _textField.text = Money.coins.ToString();
    }

    public void ChangeMoney(int amount, bool isAdd)
    {
        if(!isAdd)
            Money.coins -= amount;
        else
            Money.coins += amount;

        _textField.text = Money.coins.ToString();
    }
}
