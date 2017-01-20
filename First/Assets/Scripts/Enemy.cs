using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float timeBetweenAttacks;
    public int attackDamage;
    public float forcePushing;

    private GameObject player;
    private Rigidbody2D rb;
    private Hero playerHealth;

    private float timer;
    private bool inRange;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
        playerHealth = player.GetComponent<Hero>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            inRange = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            inRange = false;
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer>=timeBetweenAttacks && inRange)
        {
            Attack();
        }
    }

    private void Push()
    {
        if (player.transform.position.x <= transform.position.x)
        {
            rb.AddForce(new Vector3(-forcePushing, player.transform.position.y + 20f, 0f));
        }
        else
        {
            rb.AddForce(new Vector3(forcePushing, player.transform.position.y + 20f, 0f));
        }
    }
    private void Attack()
    {
        timer = 0f;
        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage, forcePushing);
            Push();
        }
    }
}
