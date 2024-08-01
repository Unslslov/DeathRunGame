using UnityEngine;

namespace Player 
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Animator))]
    public class Movement : MonoBehaviour
    {
    [SerializeField] private Joystick _joystick;
    [SerializeField] FixedTouchField  _jumpInput;

    [Header("GroundChecker Settings")]
    [SerializeField] private LayerMask _gorundMask;
    [SerializeField] private Transform _groundCheckerPivot;
    [SerializeField] private float _checkGroundRadius = 0.4f; 

    [Header("Movement Settings")]
    [SerializeField] private float _gravity;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    [Header("Accelerate")]
    [SerializeField] private float _acceleration = .5f;
    [SerializeField] private float _deceleration = .5f;
    [SerializeField] private float _maxSpeed;

    [Header("Speedometr")]
    [SerializeField] private Speedometer speedometer; 

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Animator _anim;
    [SerializeField] private float  _velocity;
    
    private Vector3 _moveDirection;
    private bool _isGrounded;
    private int countJump;
    private float _startSpeed;


    private void OnValidate() 
    {
        _rb ??= GetComponent<Rigidbody>();
        _anim ??= GetComponent<Animator>();
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
        // _moveDirection = transform.right * _joystick.Horizontal + transform.forward * _joystick.Vertical;

        // DoAnimate(_moveDirection);
        
        // if(_isGrounded && _jumpInput.isJumping)
        // {
        //    Jump();
        // }
        // else if(!_isGrounded && _jumpInput.isJumping && _moveDirection.z != 0)
        // {
        //     _speed = Mathf.Lerp(_speed, _maxSpeed, _acceleration * Time.deltaTime);

        //     speedometer?.GetTargetVelocity(_speed);
        // }
        // else if(_jumpInput.isJumping == false)
        // {
        //     _speed = Mathf.Lerp(_speed, _startSpeed, _deceleration * Time.deltaTime);

        //     speedometer?.GetTargetVelocity(_speed);
        // }
        _moveDirection = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");

        DoAnimate(_moveDirection);
        
        //    countJump = 0;
        //    countJump += 1;
        // else if(countJump == 1) //&& TODO: DoubleClickInput)
        // {

        // }
        if(_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
           Jump();  
        }
        else if(!_isGrounded && Input.GetKeyDown(KeyCode.Space) && _moveDirection.z != 0)
        {
            _speed = Mathf.Lerp(_speed, _maxSpeed, _acceleration * Time.deltaTime);

            speedometer?.GetTargetVelocity(_speed);
        }
        else if(Input.GetKeyDown(KeyCode.Space) == false)
        {
            _speed = Mathf.Lerp(_speed, _startSpeed, _deceleration * Time.deltaTime);

            speedometer?.GetTargetVelocity(_speed);
        }
    }


    private void Jump()
    {
        _velocity = Mathf.Sqrt(_jumpForce * -2 * _gravity);

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

    public void SetMovementSettings(KnifeСell knifeCell)
    {
        _speed = knifeCell.Speed;
        _gravity = knifeCell.Gravity;
        _jumpForce = knifeCell.JumpForce;

        _startSpeed = _speed;
    }
    }
}