using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationHandler : MonoBehaviour
{
    public Transform _rotationTargetHorizontal;
    public Transform _rotationTargetVertical;
    [SerializeField] private GamePlayInputManager _inputManager;
    [SerializeField] private float _sensitivity = 1f;
    [SerializeField] private float _minVerticalAngle = -90f;
    [SerializeField] private float _maxVerticalAngle = 90f;


    public float horizontal = 0f;
    private float vertical = 0f;

    private void Start() 
    {
       _inputManager.RotationInputReceived += OnRotationInputReceived; 
    }

    private void OnDestroy() 
    {
       _inputManager.RotationInputReceived -= OnRotationInputReceived;     
    }

    private void OnRotationInputReceived(Vector2 delta)
    {
        var dt = Time.deltaTime;
        vertical -= _sensitivity * delta.y * dt;
        horizontal += _sensitivity * delta.x * dt;

        vertical = Mathf.Clamp(vertical, _minVerticalAngle, _maxVerticalAngle);
        _rotationTargetHorizontal.localEulerAngles = new Vector3(vertical, 0f, 0f);
        _rotationTargetVertical.localEulerAngles = new Vector3(0f, horizontal, 0f);
    }
}
