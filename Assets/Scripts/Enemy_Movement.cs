 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    private bool isChasing;
    public float speed;
    private Rigidbody2D rb;
    private Transform player;
    public LayerMask obstacleLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (isChasing == true)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * speed;

            transform.up = direction;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player == null)
            {
                player = collision.transform;
            }  
            
            // Player is IN the circle at this point.
            // Check for obstacles.
            Vector2 direction = (player.position - transform.position).normalized;
            RaycastHit2D hit = Physics2D.Raycast(
                transform.position,
                direction,
                direction.magnitude,
                obstacleLayer);

            if (hit)
            {
                Debug.Log(hit.collider.gameObject.name);
            }
            else
            {
                isChasing = true;
                Debug.Log("Clear line of sight!");
            }
            
            Debug.DrawLine(
                transform.position,
                player.transform.position,
                hit ? Color.red : Color.green,
                1f,
                false);
        }  
    }
     
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isChasing = false;
            rb.velocity = Vector2.zero;
        }
    }
}
