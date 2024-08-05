using TMPro;
using UnityEngine;

public class BuyMessage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _message;
    [HideInInspector] public string  _knife;
    private string _originText;
    
    private void Awake() 
    {
        _originText = _message.text;
    }

    private void OnEnable()
    {
        _message.text = _message.text + " " + _knife;
    }

    private void OnDisable() 
    {
        _message.text = _originText;
    }
}
