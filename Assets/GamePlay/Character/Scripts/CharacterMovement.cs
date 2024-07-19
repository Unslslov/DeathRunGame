using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    public CharacterController characterController;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Button  _buttonJump;


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

    private Animator anim;

    private void Awake() 
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        startSpeed = _speed;
    }

    private void FixedUpdate() 
    {
        _isGrounded = Physics.CheckSphere(_groundCheckerPivot.position, _checkGroundRadius, _gorundMask);
        
        if(_velocity < 0 && _isGrounded)
        {
            _velocity = -2f;
        }
    
        Move(_moveDirection);
        DoGravity();
    }
    
    private void Update()
    {
        _moveDirection = transform.right * _joystick.Horizontal + transform.forward * _joystick.Vertical;
        DoAnimate(_moveDirection);
        
        bool isSpaceHold = Input.GetKey(KeyCode.Space);

        //TODO: Create JumpButton
        //bool isButtonHold = (_buttonJump);        
        if(_isGrounded && isSpaceHold)
        {
            Jump();
          // _buttonJump.onClick.AddListener(Jump);
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

    private void DoAnimate(Vector3 move)
    {
        float speed = Mathf.Max(Mathf.Abs(move.x), Mathf.Abs(move.z));

        anim.SetFloat("Speed", speed);
        // anim.SetFloat("Speed", Mathf.Abs(move.z) > 0 ? Mathf.Abs(move.z) : Mathf.Abs(move.x) > 0 ? Mathf.Abs(move.x) : 0);
    }
}
