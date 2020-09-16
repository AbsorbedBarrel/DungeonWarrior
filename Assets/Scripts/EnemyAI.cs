using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public GameObject player;
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    Vector2 velocity = new Vector2(1.0f, 1.0f);
    Vector2 playerPos;
    private int attackRandom = 5;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;


    public AudioManager audioManager;

    public int maxHealth = 20;
    int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        if (currentHealth < maxHealth)
        {
            if (Random.Range(0, 25000) == 5)
            {
                currentHealth += 1;
                healthBar.SetHealth(currentHealth);
            }
        }
        if (currentHealth <= 0) 
        {
            Time.timeScale = 0f;
        }
    }

    void FixedUpdate() 
    {
        Vector2 lookDir = playerPos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        rb.velocity = lookDir/2;
        if (Random.Range(0, 10) == attackRandom) 
        {
            Attack();
        }
    }

    void Attack()
    {
        //Play Animation - Later
        //animator.SetTrigger("Attack");
        //Check for enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        //Destroy Enemies
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Player Hit");
            audioManager.Play("Sword-Attack");
            TakeDamage(1);
        }

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) { return; }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        audioManager.Play("Hurt");
    }
}
