using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyTD : MonoBehaviour
{
    public Transform player;

    public int health;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2.MoveTowards(transform.position, player.position, speed);
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
}
