using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FPSPlayerMovement : MonoBehaviour
{
    [Header("Movement Variables")]
    public float movementSpeed;
    public float speedMultiplier;
    public float groundDrag;
    public float raycastLength;
    
    [SerializeField]
    bool isGrounded;

    public LayerMask groundLayer;

    public Transform orientation;

    public TextMeshProUGUI healthTxt;
    
    public float myHealth;

    float horizontalInput;
    float verticalInput;

    [Header("Jump Variables")]
    public float jumpForce;
    public float jumpCooldown;
    public float airSpeedMultiplier;

    [SerializeField]
    bool readyToJump;

    Vector3 moveDirection;

    Rigidbody myRb;

    public void TakeDamage(float damageTaken)
    {
        myHealth -= damageTaken;
        print(myHealth);
    }

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        myRb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        healthTxt.text = myHealth.ToString("000");

        isGrounded = Physics.Raycast(transform.position, Vector3.down, raycastLength, groundLayer);

        PlayerInput();
        LimitSpeed();

        if (isGrounded)
        {
            myRb.drag = groundDrag;
        }
        else
        {
            myRb.drag = 0f;
        }
    }

    void FixedUpdate()
    {
        MovePlayer(); 
    }

    void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.Space) && readyToJump && isGrounded)
        {
            Jump();
         
            readyToJump = false;

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (isGrounded)
        {
            myRb.AddForce(moveDirection.normalized * movementSpeed * speedMultiplier, ForceMode.Force);
        }
        else if(!isGrounded)
        {
            myRb.AddForce(moveDirection.normalized * movementSpeed * airSpeedMultiplier, ForceMode.Force);
        }
    }

    void LimitSpeed()
    {
        Vector3 playerVel = new Vector3(myRb.velocity.x, 0f, myRb.velocity.z);

        if (playerVel.magnitude > movementSpeed)
        {
            Vector3 velLimit = playerVel.normalized * movementSpeed;
            myRb.velocity = new Vector3(velLimit.x, myRb.velocity.y, velLimit.z);
        }
    }

    void Jump()
    {
        //reset y velocity
        myRb.velocity = new Vector3(myRb.velocity.x, 0f, myRb.velocity.z);

        myRb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void ResetJump()
    {
        readyToJump = true;
    }
}
