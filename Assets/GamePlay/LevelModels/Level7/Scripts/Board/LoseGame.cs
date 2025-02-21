using TMPro;
using UnityEngine;

public class LoseGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentPlayerRunTime;
    [SerializeField] private StopWatch _stopWatch;

    private void OnEnable() 
    {
        _stopWatch.isActive = false;

        _currentPlayerRunTime.text = _stopWatch.TimerString;
    }
}
