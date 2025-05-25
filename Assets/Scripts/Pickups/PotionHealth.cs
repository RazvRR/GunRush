using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PotionHealth : PotionBase
{
    public int HealthToAdd = 2;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Player_Movement playerMoveComp = collision.gameObject.GetComponent<Player_Movement>();
        if (playerMoveComp != null) // Is player?
        {
            HealthManager healthManager = collision.gameObject.GetComponent<HealthManager>();
            int healthAdded = healthManager.ChangeHealth(HealthToAdd);

            DestroyPotion();
        }
    }
}
