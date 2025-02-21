<<<<<<< HEAD
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
=======
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
>>>>>>> 98236c49dfff302f88907e51afced8444c372b7e
