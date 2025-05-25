using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect; // Prefab for the hit effect
    public float timeToShowEffect = 2f;
    
    public float bulletForce = 20f; // The force with which the bullet will be fired
    public int damage = 1;
    
    public LayerMask[] obstacleLayers;

    private void DestroyBullet()
    {
        // Instantiate the hit effect at the collision point and destroy it after 1 second
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, timeToShowEffect);
        Destroy(gameObject);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        HealthManager healthMng = collision.gameObject.GetComponent<HealthManager>();
        if (healthMng != null)
        {
            healthMng.ChangeHealth(-damage);
        }

        DestroyBullet();
    }
}
