using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFightingController : MonoBehaviour
{
    public Animator anim;

    public Transform body, groundChecker;

    public float speed, jumpForce, comboTimer = 1f;

    public int health = 20;

    public bool ground;

    Rigidbody rb;

    float countdown, move;

    bool combo, forward, backward;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        countdown = comboTimer;
    }

    // Update is called once per frame
    void Update()
    {
        //Tracking
        body.position = transform.position;

        //Movement
        move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(move * speed * Time.deltaTime, rb.velocity.y, rb.velocity.z);

        //Jumping
        if (Input.GetKey(KeyCode.Space) && ground)
        {
            //rb.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode.Impulse);
            rb.velocity = Vector3.up * jumpForce * Time.deltaTime;
            ground = false;
            anim.SetTrigger("Jump");
        }

        //Animation Movement
        if (Input.GetKey(KeyCode.A) && !forward)
        {
            anim.SetBool("Backward", true);
            anim.SetBool("IsWalking", true);
            backward = true;
        }
        else if(Input.GetKey(KeyCode.D) && !backward)
        {
            anim.SetBool("Forward", true);
            anim.SetBool("IsWalking", true);
            forward = true;
        }
        else
        {
            anim.SetBool("Forward", false);
            anim.SetBool("Backward", false);
            anim.SetBool("IsWalking", false);
            forward = false;
            backward = false;
        }

        //Combo System animation
        if (combo)
        {
            countdown -= Time.deltaTime;

            if (countdown <= 0)
            {
                countdown = comboTimer;
                combo = false;
                anim.SetBool("Fail", true);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("IsWalking", false);

            anim.SetTrigger("Punch");
            anim.SetBool("Fail", false);

            combo = true;
        }

        if (Input.GetMouseButtonDown(1))
        {
            anim.SetBool("IsWalking", false);

            anim.SetTrigger("Kick");
            anim.SetBool("Fail", false);

            combo = true;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            //Game Over
        }
    }
}
