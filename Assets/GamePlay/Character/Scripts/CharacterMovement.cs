using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    public CharacterController characterController;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private CameraRotationHandler cameraRotation;

    [Header("GroundChecker Settings")]
    [SerializeField] private LayerMask _gorundMask;
    [SerializeField] private Transform _groundCheckerPivot;
    [SerializeField] private float _checkGroundRadius = 0.4f;

    [Header("Movement Settings")]
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float jumpHeight = 3f;

    [Header("Accelerate")]
    [SerializeField] private float _acceleration = .5f;
    [SerializeField] private float _deceleration = -.5f;
    [SerializeField] private float _maxSpeed;

    [Header("Speedometr")]
    [SerializeField] private Speedometer speedometer; 

    private float  _velocity;
    private bool _isGrounded;
    private Vector3 _moveDirection;
    private float startSpeed;

    private void Awake() 
    {
        characterController = GetComponent<CharacterController>();
        startSpeed = _speed;
    }

    private void FixedUpdate() 
    {
        _isGrounded = Physics.CheckSphere(_groundCheckerPivot.position, _checkGroundRadius, _gorundMask);
        if(_isGrounded && _velocity < 0)
        {
            _velocity = -2f;
        }
    
        Move(_moveDirection);
        DoGravity();
    }
    
    private void Update()
    {
        _moveDirection = transform.right * _joystick.Horizontal + transform.forward * _joystick.Vertical;
        
        bool isSpaceHold = Input.GetKey(KeyCode.Space);

        if(_isGrounded && isSpaceHold)
        {
            Jump();
        }
        else if(!_isGrounded && isSpaceHold && _moveDirection.z != 0)
        {
            if(_maxSpeed > _speed)
                _speed = Mathf.Lerp(_speed, _maxSpeed, _acceleration * Time.deltaTime);
            speedometer?.GetTargetVelocity(_speed);
        }
        else if(!isSpaceHold)
        {
            if(_speed > startSpeed)
                _speed = Mathf.Lerp(_speed, startSpeed, _deceleration * Time.deltaTime);
            speedometer?.GetTargetVelocity(_speed);
        }
    }

    private void Jump()
    {
        _velocity = Mathf.Sqrt(jumpHeight * -2 * _gravity);
    }

    private void Move(Vector3 direction)
    {
        characterController.Move(direction * _speed * Time.fixedDeltaTime);
    }

    private void DoGravity()
    {
        _velocity += _gravity * Time.fixedDeltaTime;

        characterController.Move(Vector3.up * _velocity * Time.fixedDeltaTime); 
    }
}
