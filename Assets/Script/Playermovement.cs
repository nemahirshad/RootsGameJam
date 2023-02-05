using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Playermovement : MonoBehaviour
{
    float horizontal;
    float speed = 8f;
    public float jumpVelocity;
    bool isFacingRight = true;
    public float maxJump;
    public float jumpCounter;
    public Animator animator;   

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask enemyLayer;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (IsGrounded())
        {
            jumpCounter = 0;
            animator.SetTrigger("Land");
        }

        if (Input.GetButtonDown ("Jump") && jumpCounter < maxJump)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;

            jumpCounter++;
            animator.SetTrigger("Jump");
        }

        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        Flip();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Head"))
        {
            Destroy(collision.transform.parent.gameObject);
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("RootofPlatformer");
        }
    }
}
