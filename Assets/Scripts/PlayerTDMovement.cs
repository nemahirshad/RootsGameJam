using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTDMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;

    public float speed;

    [HideInInspector]
    public Vector2 movement;

    //Animator anim;
    Vector2 mousePos;

    private void Start()
    {
        //myStats = GetComponent<PlayerStats>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0 || movement.y != 0)
        {
            //anim.SetBool("IsMoving", true);
        }
        else
        {
            //anim.SetBool("IsMoving", false);
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        float mouseDirX = mousePos.x - transform.position.x;
        float mouseDirY = mousePos.y - transform.position.y;

        //anim.SetFloat("X", mouseDirX);
        //anim.SetFloat("Y", mouseDirY);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
