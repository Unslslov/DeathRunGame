using System;
using UnityEngine;

public class TimeInvoker : MonoBehaviour
{
    public event Action<float> OnUpdateTimeTickedEvent;
    public event Action<float> OnUpdateTimeUnscaledTickedEvent;
    public event Action OnOneTimeTickedEvent;
    public event Action OnOneTimeUnscaledTickedEvent;

    public static TimeInvoker instance 
    {
        get 
        {
            if(_instance == null)
            {
                var go = new GameObject("TimeInvoker");
                _instance = go.AddComponent<TimeInvoker>();
                // if you want to destroy this object, you can remove DontDestroyOnLoad
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }
    private static TimeInvoker _instance;

    private float _oneSecTimer;
    private float _oneSecUnscaledTimer;

    private void Update() 
    {
        var deltaTime = Time.deltaTime;
        OnUpdateTimeTickedEvent?.Invoke(deltaTime);    

        _oneSecTimer += deltaTime;
        if(_oneSecTimer >= 1f)
        {
            _oneSecTimer -= 1;
            OnOneTimeTickedEvent?.Invoke();
        }

        var unscaledDeltaTime = Time.unscaledDeltaTime;
        OnUpdateTimeUnscaledTickedEvent?.Invoke(unscaledDeltaTime);

        _oneSecUnscaledTimer += unscaledDeltaTime;
        if(_oneSecUnscaledTimer  >= 1f)
        {
            _oneSecUnscaledTimer -= 1;
            OnOneTimeUnscaledTickedEvent?.Invoke();

        }

    }
}
