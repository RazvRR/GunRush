using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
public class ExperienceManager : MonoBehaviour
{
    public int  level;
    public int currentXP;
    public int xpToNextLevel = 10;
    public float expGrowthMultiplier = 1.5f;
    public Slider XpSlider; // Reference to the UI Slider
    public TMP_Text currentLevelText; // Reference to the UI Text for level display

    private void Start()
    {  
    UpdateUI();
    }

    // private void Update()
    // {
    //     // Example of gaining experience
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         GainExperience(2);
    //     }
    // }

    private void OnEnable()
    {
        // Subscribe to the event when the player gains experience
        HealthManager.OnMonsterDefeated += GainExperience;
    }
     private void OnDisable()
    {
        // Subscribe to the event when the player gains experience
        HealthManager.OnMonsterDefeated -= GainExperience;
    }

    public void GainExperience(int amount)
    {
        currentXP += amount;
        if (currentXP >= xpToNextLevel)
        {
            LevelUp();
        }
        UpdateUI(); // Update the UI after gaining experience
    }

    private void LevelUp()
    {
        level++;
        currentXP -= xpToNextLevel;
        xpToNextLevel = Mathf.FloorToInt(xpToNextLevel * expGrowthMultiplier); // Increase XP needed for next level
        Debug.Log("Leveled up! New level " + level);
    }

    public void UpdateUI()
    {
        XpSlider.maxValue = xpToNextLevel;
        XpSlider.value = currentXP;
        currentLevelText.text = "Level " + level;
    }
}