using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScene : MonoBehaviour {

    public Text highScoreText;

	// Use this for initialization
	void Start ()
    {
		highScoreText.text= PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
