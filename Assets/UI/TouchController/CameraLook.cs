using UnityEngine;
using Unsl;

public class CameraLook : MonoBehaviour, ISource<float>
{
    [SerializeField] private Transform _Characterbody;
    [SerializeField] private FixedTouchField _fixedTouchField;
    [SerializeField] private float Sensivity = 0.1f;
    public Vector2 LockAxis;

    private float _xMove;
    private float _yMove;
    private float _xRotation;

    private void Start() 
    {
        SourceInitialize(0);
    }

    void Update()
    {
        LockAxis = _fixedTouchField.TouchDist;

        _xMove = LockAxis.x * Sensivity; //* Time.deltaTime/2f;
        _yMove = LockAxis.y * Sensivity; //* Time.deltaTime/2f;

        _xRotation -= _yMove;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        _Characterbody.Rotate(Vector3.up * _xMove);
    }

    public void SetSensivity(float sensivity)
    {
        Sensivity = sensivity;
    }

    public void SourceInitialize(float source)
    {
        var settingValue = FileSaveLoad.LoadList<float>(TypeSave.Settings);

        if(settingValue != null)
        {
            Sensivity = settingValue.ListObjects[2];
        }
    }
}
