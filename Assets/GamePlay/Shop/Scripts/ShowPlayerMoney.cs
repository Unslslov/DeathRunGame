using TMPro;
using UnityEngine;

public class ShowPlayerMoney : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textField;

    private void OnEnable() 
    {
        Show();
    }

    private void Show()
    {
        var money = Money.coins;

        _textField.text = money.ToString();
    }
}
