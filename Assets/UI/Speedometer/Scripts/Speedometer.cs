using UnityEngine;
using TMPro;

public class Speedometer : MonoBehaviour

{
    [SerializeField] private TextMeshProUGUI label;
    private string text;

    private void Awake() 
    {
        label.text = "5";
    }

    public void GetTargetVelocity(float speed)
    {
        label.text = speed.ToString("F1").Replace(",", "");
    }
}
