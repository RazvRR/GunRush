using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionUpgrade : PotionBase
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Player_Movement playerMoveComp = collision.gameObject.GetComponent<Player_Movement>();
        if (playerMoveComp != null) // Is player?
        {
            UpgradeManager upgradeManager = collision.gameObject.GetComponent<UpgradeManager>();
            ++upgradeManager.UpgradeLevel;
            
            DestroyPotion();
        }
    }
}
