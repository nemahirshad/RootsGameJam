using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    float horizontal;
    float speed = 8f;
    public float jumpVelocity;
    bool isFacingRight = true;
    public float maxJump;
    public float jumpCounter;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (IsGrounded())
        {
            jumpCounter = 0;
        }

        if (Input.GetButtonDown ("Jump") && jumpCounter < maxJump)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;

            jumpCounter++;
        }

        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        Flip();
    }

    void FixedUpdate()
    {
        
    }

    bool IsGrounded()
    { 
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void Flip()
    { 
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
