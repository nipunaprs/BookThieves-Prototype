using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManv1 : MonoBehaviour
{
    public Text playerHealth;
    public Text currentEnemyHealth;
    int currentPlayerHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        //Restart if playerhealth goes to zero
        if(currentPlayerHealth <= 0)
        {
            GameManagerLvl3.levelName= SceneManager.GetActiveScene().buildIndex;
            RestartLvl();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void RestartLvl()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Restart");

    }


    public void GoToNext()
    {
        SceneManager.LoadScene(2);
    }

    public void UpdatePlayerHealth(int health)
    {
        playerHealth.text = "Health: "+ health.ToString();
        currentPlayerHealth = health;
    }

    public void UpdateEnemyHealth(int health)
    {
        currentEnemyHealth.text = "Current Enemy: " + health.ToString();
    }
}
