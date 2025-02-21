using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Sliding : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _orientation;
    [SerializeField] private Transform _playerObj;
    [SerializeField] private Rigidbody _rb;

    [Header("Sliding")]
    [SerializeField] private float _slideForce = 200f;
    [SerializeField] private float _slideYScale = 0.5f;
    [SerializeField] private float _gravity = 50f;

    [Header("TestScales")]
    [SerializeField ]private Vector3 _startYScale;
    public  bool IsSliding { get; private set; }

    [Header("Input")]
    [SerializeField] private Joystick _joystick;

    private void OnValidate() 
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Awake() 
    {
        _startYScale = _playerObj.localScale;
    }

    private void FixedUpdate() 
    {
        if(IsSliding == true)
            SlidingMovement();
    }

    public void StartSliding()
    {
        IsSliding = true;

        _playerObj.localScale = new Vector3(_playerObj.localScale.x, _slideYScale, _playerObj.localScale.z);
        _rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
    }

    private void SlidingMovement()
    {
        Vector3 inputDirection = _joystick.Vertical * _orientation.forward + _joystick.Horizontal * _orientation.right;

        _rb.AddForce(inputDirection.normalized * _slideForce + Vector3.down * _gravity, ForceMode.Force);
    }

    public void EndSliding()
    {
        IsSliding = false;

        _playerObj.localScale = _startYScale;

        this.enabled = false;
    }
}
