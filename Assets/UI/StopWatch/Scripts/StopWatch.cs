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
