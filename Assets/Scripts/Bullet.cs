using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect; // Prefab for the hit effect
    public float timeToShowEffect = 2f;
    private int damageToDeal;

    public void SetDamage(int damage)
    {
        damageToDeal = damage;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        HealthManager healthMng = collision.gameObject.GetComponent<HealthManager>();
        if (healthMng != null)
        {
            healthMng.ChangeHealth(-damageToDeal);
        }

        // Instantiate the hit effect at the collision point and destroy it after 1 second
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, timeToShowEffect);
        Destroy(gameObject);
    }
}
