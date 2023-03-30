using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerLvl3 : MonoBehaviour
{
    public Text playerHealth;
    public Text bossHealth;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        playerHealth.text = health.ToString();
    }

    public void UpdateBossHealth(int health)
    {
        bossHealth.text = health.ToString();
    }
}
