using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSEnemy : MonoBehaviour
{
    public GameObject thePlayer;

    public float myHealth;
    public float myDamage;
    public float speed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (myHealth <= 0)
        {
            Destroy(gameObject);
        }
        transform.LookAt(thePlayer.transform);
        transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            thePlayer.GetComponent<FPSPlayerMovement>().TakeDamage(myDamage);
            myHealth = 0;
            Destroy(gameObject);
        }
    }
}
