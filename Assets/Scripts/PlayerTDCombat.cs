using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTDCombat : MonoBehaviour
{
    public Transform attackPoint;

    public Animator animator;
    public AudioSource playSoundMelee;

    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    public int damage;

    public int maxHealth;

    float cooldown;

    int health;

    [SerializeField] HeartSystem heartSystem;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
            playSoundMelee.Play();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyTD>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    public void TakeDamage(int dmg)
    {
        if (health > 0)
        {
            health -= dmg;
            heartSystem.DrawHearts(health, maxHealth);
        }
    }
}
