using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private Transform _Characterbody;
    // [SerializeField] private FixedTouchField _fixedTouchField;

    public float Sensivity = 40f;
    public Vector2 LockAxis;

    private float _xMove;
    private float _yMove;
    private float _xRotation;
    
    void Update()
    {
        // LockAxis = _fixedTouchField.TouchDist;

        _xMove = LockAxis.x * Sensivity * Time.deltaTime;
        _yMove = LockAxis.y * Sensivity * Time.deltaTime;

        _xRotation -= _yMove;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation,0,0);
        _Characterbody.Rotate(Vector3.up * _xMove);
    }
}
