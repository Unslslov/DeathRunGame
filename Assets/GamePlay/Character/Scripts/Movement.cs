using UnityEngine;
using UnityEngine.UI;

namespace Player 
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Animator))]
    public class Movement : MonoBehaviour
    {
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
    [SerializeField] private float _deceleration = .5f;
    [SerializeField] private float _maxSpeed;

    [Header("Speedometr")]
    [SerializeField] private Speedometer speedometer; 

    private Rigidbody _rb;
    private Animator _anim;
    private Vector3 _moveDirection;
    private float  _velocity;
    private bool _isGrounded;
    private float _startSpeed;


    private void OnValidate() 
    {
        _rb ??= GetComponent<Rigidbody>();
        _anim ??= GetComponent<Animator>();
    }

    private void Awake() 
    {
        _startSpeed = _speed;
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
        //   _buttonJump.onClick.AddListener(Jump);
           Jump();
        }
        else if(!_isGrounded && isSpaceHold && _moveDirection.z != 0)
        {
            _speed = Mathf.Lerp(_speed, _maxSpeed, _acceleration * Time.deltaTime);

            speedometer?.GetTargetVelocity(_speed);
        }
        else if(isSpaceHold == false)
        {
            _speed = Mathf.Lerp(_speed, _startSpeed, _deceleration * Time.deltaTime);

            speedometer?.GetTargetVelocity(_speed);
        }
    }

    private void Jump()
    {
        _velocity = Mathf.Sqrt(jumpHeight * -2 * _gravity);

        _rb.velocity = new Vector3(_rb.velocity.x, _velocity, _rb.velocity.z);
    }

    private void Move(Vector3 direction)
    {
        _rb.velocity = new Vector3(direction.x * _speed, _rb.velocity.y, direction.z * _speed);
    }

    private void DoGravity()
    {
        _velocity += _gravity * Time.fixedDeltaTime;
    }

    private void DoAnimate(Vector3 move)
    {
        float speed = Mathf.Max(Mathf.Abs(move.x), Mathf.Abs(move.z));

        _anim.SetFloat("Speed", speed);
        // _anim.SetFloat("Speed", Mathf.Abs(move.z) > 0 ? Mathf.Abs(move.z) : Mathf.Abs(move.x) > 0 ? Mathf.Abs(move.x) : 0);
    }
    }
}