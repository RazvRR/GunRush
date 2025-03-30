using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public Slider healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth; // Corectare: folosește healthBar
        healthBar.value = currentHealth;
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Asigură-te că sănătatea rămâne între 0 și maxHealth
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false); // Dezactivează obiectul când sănătatea ajunge la 0
        }
    }
}