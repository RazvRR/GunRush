using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform FirePoint; // The point from where the bullet will be fired
    public Bullet bulletPrefab; // The bullet prefab to be instantiated 

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
        Bullet newBullet = Instantiate<Bullet>(bulletPrefab, FirePoint.position, 
            bulletPrefab.transform.rotation * transform.rotation);
        
        // Get the Rigidbody component of the bullet
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        
        // Add force to the bullet in the forward direction of the fire point
        rb.AddForce(FirePoint.up * newBullet.bulletForce, ForceMode2D.Impulse);
    }
}
