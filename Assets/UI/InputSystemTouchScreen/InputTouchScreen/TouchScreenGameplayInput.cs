using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchScreenGameplayInput
{
    public event Action<Vector2> RotationInputReceived;

    private readonly InputMap _inputMap;
    private readonly RectTransform _inputRotationZone;

    private int _i;

    public TouchScreenGameplayInput(InputMap inputMap, RectTransform inputRotationZone)
    {
        _inputMap = inputMap;
        _inputRotationZone = inputRotationZone;

        _inputMap.TouchScreen.TouchPress.started += OnTouchPressStarted;
        _inputMap.TouchScreen.TouchPress.canceled += OnTouchPressCanceled;

        // int ist = _inputMap.TouchScreen.TouchPress.;


        Debug.Log(_inputMap.TouchScreen.TouchPress.controls.Count);
        if(_inputMap.TouchScreen.TouchPress.controls.Count > 1)
        {
        }
    }

    private void OnTouchPressStarted(InputAction.CallbackContext context)
    {
        var currentTouchPosition = _inputMap.TouchScreen.TouchPosition.ReadValue<Vector2>();
        var isTouchInRect = 
            RectTransformUtility.RectangleContainsScreenPoint(_inputRotationZone, currentTouchPosition);

        if(isTouchInRect)
        {
            _inputMap.TouchScreen.TouchDelta.performed += TouchDeltaPerformed;
        }
    }
    private void OnTouchPressCanceled(InputAction.CallbackContext context)
    {
        _inputMap.TouchScreen.TouchDelta.performed -= TouchDeltaPerformed;
    }

    private void TouchDeltaPerformed(InputAction.CallbackContext context)
    {
        RotationInputReceived?.Invoke(context.ReadValue<Vector2>());
    }
}
