using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    public FixedJoystick joystick;
    public float SpeedMove = 5f;
    
    private CharacterController controller;

    void Start()
    {
        controller= GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 Move = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;
        controller.Move(Move * SpeedMove * Time.deltaTime);
    }
}
