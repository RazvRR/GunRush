using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform FirePoint; // The point from where the bullet will be fired
    public GameObject bulletPrefab; // The bullet prefab to be instantiated 

    public float bulletForce = 20f; // The force with which the bullet will be fired
    public int damage = 1;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) // Check if the fire button is pressed (usually left mouse button or Ctrl)
        {
            Shoot(); // Call the Shoot method to fire a bullet
        }
    }

    void Shoot()
    {
        // Instantiate the bullet at the fire point's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, FirePoint.position, 
            bulletPrefab.transform.rotation * transform.rotation);
        
        Bullet bulletComp = bullet.GetComponent<Bullet>();
        bulletComp.SetDamage(damage);
        
        // Get the Rigidbody component of the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        
        // Add force to the bullet in the forward direction of the fire point
        rb.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
