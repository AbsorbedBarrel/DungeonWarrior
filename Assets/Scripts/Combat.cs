using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
public class Combat : MonoBehaviour
{
    //public Animator animator

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    int score = 0;
    public GameObject scoreText;
    public AudioManager audioManager;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Debug.Log("Attacking");
            Attack();
        }
        scoreText.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
    }

    void Attack() 
    {
        //Play Animation - Later
        //animator.SetTrigger("Attack");
        //Check for enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        audioManager.Play("Sword-Attack");
        //Destroy Enemies
        foreach (Collider2D enemy in hitEnemies) 
        {
            Debug.Log("Enemy Hit:" + enemy.name);
            Destroy(enemy.gameObject);
            FindObjectOfType<AudioManager>().Play("Enemy-Destroy");
            score += 1;
        }
    }

    void OnDrawGizmosSelected() 
    {
        if (attackPoint == null) { return; }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    
}
