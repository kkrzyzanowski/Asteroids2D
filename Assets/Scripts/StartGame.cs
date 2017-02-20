using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public Text highscore;
    
     void Start()
    {
        highscore.text = "Highscore: " + ((int)PlayerPrefs.GetInt("Highscore")).ToString();
    }
	public void start(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
