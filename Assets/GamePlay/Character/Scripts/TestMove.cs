using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class TestMove : MonoBehaviour
{
    public CharacterController characterController;
    [SerializeField] private Joystick _joystick;

    [Header("Movement Settings")]
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float jumpHeight = 3f;

    private float  _velocity;
    private Vector3 _moveDirection;

    private Animator anim;

    private void Awake() 
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate() 
    {
        Move(_moveDirection);
        DoGravity();
    }
    
    private void Update()
    {
        _moveDirection = transform.right * _joystick.Horizontal + transform.forward * _joystick.Vertical;
        DoAnimate(_moveDirection);
        
        bool isSpaceHold = Input.GetKey(KeyCode.Space);  

        if(isSpaceHold)
        {
            Jump();
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

