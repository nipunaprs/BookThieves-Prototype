using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerLvl3 : MonoBehaviour
{
    public Text playerHealth;
    public Text bossHealth;
    public Text enemyHealth;

    public int localPlayerhealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        //Restart if playerhealth goes to zero
        if (localPlayerhealth <= 0)
        {
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void GoToEnd()
    {
        SceneManager.LoadScene(2);
    }

    public void UpdatePlayerHealth(int health)
    {
        playerHealth.text = "Health: " + health.ToString();
        localPlayerhealth = health;
    }

    public void UpdateBossHealth(int health)
    {
        bossHealth.text = "Boss: " + health.ToString();
    }

    public void UpdateEnemyHealth(int health)
    {
        enemyHealth.text = "Current Enemy: " +health.ToString();
    }
}
