using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightingGameAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float attackRange = 1f;
    public float attackChance = 0.2f;
    public float specialMoveChance = 0.1f;
    public int health = 100;
    public Slider healthBar;

    Transform playerTransform;
    
    bool facingRight;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        healthBar.value = health;
    }

    private void Update()
    {
        // Face player
        Flip();

        // Check if in attack range
        if (Vector3.Distance(transform.position, playerTransform.position) < attackRange)
        {
            // Randomly attack or use special move
            float attackOrSpecial = Random.Range(0f, 1f);
            if (attackOrSpecial <= attackChance)
            {
                // Punch or kick
                int attack = Random.Range(0, 2);
                if (attack == 0)
                {
                    Debug.Log("AI punched");
                }
                else
                {
                    Debug.Log("AI kicked");
                }
            }
            else if (attackOrSpecial <= specialMoveChance)
            {
                Debug.Log("AI used special move");
            }
        }
        else
        {
            // Move towards player
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerTransform.position.x, transform.position.y, transform.position.z), moveSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.value = health;
        if (health <= 0)
        {
            Debug.Log("AI died");
            //Cutscene
        }
    }

    void Flip()
    {
        if (transform.position.x > playerTransform.position.x && facingRight)
        {
            transform.Rotate(new Vector3(0, 180, 0));
            facingRight = false;
        }
        if (transform.position.x < playerTransform.position.x && !facingRight)
        {
            transform.Rotate(new Vector3(0, -180, 0));
            facingRight = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hitboxes"))
        {
            TakeDamage(1);
        }
    }
}
