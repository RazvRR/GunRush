using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public TMP_Text enemyCounterText;
    public GameObject victoryScreen;
    public GameObject lastEnemyAlive;
    public int victoryTimer = 5;

    private void Start()
    {
        UpdateEnemiesCounter(0);
    }

    private void OnEnable()
    {
        HealthManager.OnMonsterDefeated += UpdateEnemiesCounter;
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Victory()
    {
        victoryScreen.SetActive(true);
        Invoke(nameof(MainMenu), victoryTimer);
    }

    private int CountEnemies()
    {
        int nrEnemies = 0;
        
        // Go through every root GameObject in the Scene, in order to find the Enemies
        GameObject[] sceneRootObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject rootObject in sceneRootObjects)
        {
            Enemy_Combat[] enemyWaveArray = rootObject.GetComponentsInChildren<Enemy_Combat>();
            
            // If the object has any enemies under it..
            if (enemyWaveArray.Length > 0)
            {
                // Check all enemies to count only alive ones
                foreach (Enemy_Combat enemy in enemyWaveArray)
                {
                    // Check for death
                    HealthManager enemyHealth = enemy.gameObject.GetComponent<HealthManager>();
                    if (!enemyHealth.IsDead())
                    {
                        nrEnemies++;
                    }
                }
            }
        }
        
        return nrEnemies;
    }

    private void UpdateEnemiesCounter(int amount)
    {
        int enemies = CountEnemies();
        enemyCounterText.text = "Enemies Left: " + enemies.ToString();

        if (lastEnemyAlive == null)
        {
            return;
        }
        
        if (enemies == 0 || lastEnemyAlive.GetComponent<HealthManager>().IsDead())
        {
            // Giga chad
            Victory();
        }
    }
}
