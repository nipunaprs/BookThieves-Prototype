using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RestartLevel()
    {
        int currentScene = GameManagerLvl3.levelName;

        SceneManager.LoadScene(currentScene);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void GoToEnd()
    {
        SceneManager.LoadScene(2);
    }
}
