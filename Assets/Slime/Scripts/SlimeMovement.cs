using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour, IMovement
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _speedUp = 5f;
    
    CharacterController characterController;
    Animator animator;
    Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();  
        characterController = gameObject.GetComponent<CharacterController>();    
    }
    public void Move()
    {
        rb.velocity += new Vector3(0, _speedUp, 0); 
    }
    void Update()
    {
        var movementAxis = Input.GetAxis("Horizontal");
        var movementVertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * movementAxis  + transform.forward * movementVertical;

        //characterController.Move(move * _speed * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
            animator.SetFloat("speed", rb.velocity.y);
            Move();
        }
    }
}
