using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;

    [Header("Combat Stats")]
    public int Damage;
    public float AttackRange;
    public float AttackSpeed;
    public float stunTime;

    [Header("Player Stats")]
    public int playerLevel;
    public int currentExp;
    public int maxLevel;
    public int stamina;
    public int maxStamina;
    public int currentStamina;
    public int staminaRegen;
    public int maxMana;
    public int currentMana;
    public int manaRegen;

    [Header("Movement Stats")]
    public int moveSpeed; 

    [Header("Health Stats")]
    public int maxHealth;
    public int currentHealth;
    public int healthRegen;
    public int armor;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

     private void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        currentMana = maxMana;
    }
}
