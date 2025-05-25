using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthManager : MonoBehaviour
{

    public int XpReward = 3;
    public delegate void MonsterDefeated(int xp);
    public static event MonsterDefeated OnMonsterDefeated;
    public int currentHealth;
    public int maxHealth;

    public Slider healthBar;
    
    public PauseMenu pauseMenu;

    private void Start()
    {
        currentHealth = maxHealth;

        InitHealthBar();
    }

    public void InitHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth; // Corectare: folosește healthBar
            healthBar.value = currentHealth;
        }
    }

    public int ChangeHealth(int amount)
    { 
        currentHealth += amount;
        currentHealth =
            Mathf.Clamp(currentHealth, 0, maxHealth); // Asigură-te că sănătatea rămâne între 0 și maxHealth

        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        // TODO: should destroy instead of hiding the object
        if (currentHealth <= 0)
        {
            OnMonsterDefeated(XpReward);
            // Dezactivează obiectul când sănătatea ajunge la 0
            gameObject.SetActive(false); 
            healthBar.gameObject.SetActive(false);
            
            // If you are a player...
            if (GetComponent<Player_Movement>())
            {
                pauseMenu.GotoMainMenu();
            }
        }

        return maxHealth - currentHealth;
    }
}