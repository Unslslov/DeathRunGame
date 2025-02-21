<<<<<<< HEAD
using TMPro;
using UnityEngine;

public class StopWatch : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _label;
    
    public bool isActive;

    public string TimerString { get; private set;}
    public float deltaTime {get; private set;}
    
    private void Start() 
    {
        TimerString = string.Format("{0:00}:{1:00}:{2:000}", 0, 0, 0);
        _label.text = TimerString;
    }

    void Update()
    {
        if(isActive)
        {
            deltaTime += Time.deltaTime;
            UpdateTimerText(deltaTime);
        }
    }

    private void UpdateTimerText(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        int milliseconds = Mathf.FloorToInt((timeInSeconds * 1000) % 1000);

        TimerString = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        _label.text = TimerString;
    }
}
=======
using TMPro;
using UnityEngine;

public class StopWatch : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _label;
    private float deltaTime;

    void Update()
    {
        deltaTime += Time.deltaTime;
        UpdateTimerText(deltaTime);
    }

    private void UpdateTimerText(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        int milliseconds = Mathf.FloorToInt((timeInSeconds * 1000) % 1000);

        string timerString = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        _label.text = timerString;
    }
}
>>>>>>> 98236c49dfff302f88907e51afced8444c372b7e
