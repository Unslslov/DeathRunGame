using System;
using UnityEngine;

public class GamePlayInputManager : MonoBehaviour
{
    public event Action<Vector2> RotationInputReceived;
    public RectTransform RotationInputZone;

    private InputMap _inputMap;
    private TouchScreenGameplayInput _touchScreenInput;

    private void Awake() 
    {
        _inputMap = new InputMap();

        _inputMap.Enable();

        InitTouchScreenInput(_inputMap);
    }

    private void InitTouchScreenInput(InputMap inputMap)
    {
        _touchScreenInput = new TouchScreenGameplayInput(inputMap, RotationInputZone);

        _touchScreenInput.RotationInputReceived += OnRotationInputReceived;
    }

    private void OnRotationInputReceived(Vector2 delta)
    {
        RotationInputReceived?.Invoke(delta);
    }
}
