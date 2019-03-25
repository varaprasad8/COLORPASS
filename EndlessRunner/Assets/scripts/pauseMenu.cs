using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{

    /*public static bool GameisPaused = false;
    public GameObject PausemenuUI;

    void Start()
    {
        
    }

    
    void Update()
 
        {
            if (GameisPaused)
                resume();
            else
                pause();
        }

    
    public void resume()
    {
        PausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }
    public void pause()
    {
        PausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }*/

    public GameObject PauseMenu;
    public GameObject PauseButton;

    public void pause()
    {
        PauseMenu.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1;
    }
    public void MenuScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("menu");
    }
    public void doQuit()
    {
        Application.Quit();
    }
    public void gameScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
}
