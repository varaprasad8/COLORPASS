using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{

    public AudioClip Button;
     AudioSource AS;

    private void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    public void changeScene()
    {
        //Debug.Log("Functioon");
        SceneManager.LoadScene("Game");
    }

    public void sceneChanger()
    {
        //Debug.Log("Function Call");
        AS.PlayOneShot(Button);
        
        Invoke("changeScene", 0.5f);
        //changeScene();

    }

    public void about()
    {
        SceneManager.LoadScene("about");
    }
   
    public void gameExit()
    {
        Application.Quit();
    }
    public void scoreScene()
    {
        
        SceneManager.LoadScene("highScore");
    }
   
    public void scoreChanger()
    {
        
        AS.PlayOneShot(Button);
        Invoke("scoreScene", 0.5f);
        
    }
    public void gameExiter()
    {
        AS.PlayOneShot(Button);
        Invoke("gameExit", 0.5f);
        
    }
}
