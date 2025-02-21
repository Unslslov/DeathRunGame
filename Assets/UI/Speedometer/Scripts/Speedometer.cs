using UnityEngine;
using TMPro;

public class Speedometer : MonoBehaviour

{
    [SerializeField] private TextMeshProUGUI label;
    private string text;

    public void GetTargetVelocity(float speed)
    {
        if(speed > 0)
            label.text = speed.ToString("F1").Replace(",", "");
    }
}
