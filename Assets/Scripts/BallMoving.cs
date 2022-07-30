using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoving : MonoBehaviour
{
    //movement
    public float speed;
    public float jumpForce;
    Rigidbody myball;
    //input
    private float horizontalMovement;
    private float verticalMovement;
    
    //Grounded
    public bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;

    Vector3 velocity;
    Vector3 moveDirection;

    void Awake()
    {
        myball = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance,groundMask);

        if (Input.GetKeyDown("space") && isGrounded)
        {
            if (isGrounded)
            {
                myball.velocity = new Vector3(myball.velocity.x, 0, myball.velocity.z);
                myball.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            }
        }

        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        myball.AddForce(new Vector3 (horizontalMovement ,0 ,verticalMovement) *speed, ForceMode.Acceleration);
    }
    
}
