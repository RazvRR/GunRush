using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
    // public int maxHealth = 100;
    // public int currentHealth;

    // public HealthBar healthBar;

    // void Start()
    // {
    //     currentHealth = maxHealth;
    //     healthBar.SetMaxHealth(maxHealth);
    // }

    // public void TakeDamage(int damage)
    // {
    //     currentHealth -= damage;
    //     healthBar.SetHealth(currentHealth);

    //     if (currentHealth <= 0)
    //     {
    //         Die();
    //     }
    // }

    // void Die()
    // {
    //     Destroy(gameObject);
    // }

    public int damage = 1;

    // TODO: refactor to distinguish between player and non-playable
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player_Movement playerMoveComp = collision.gameObject.GetComponent<Player_Movement>();
        if (playerMoveComp != null)
        {
            HealthManager healthMng = collision.gameObject.GetComponent<HealthManager>();
            if (healthMng)
            {
                healthMng.ChangeHealth(-damage);
            }
        }
    }
}
