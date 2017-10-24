using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {


	public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Application.Quit();
    }

    //Gets the buildIndex of the current scene adds 1 and loads that scene
    public void LoadNextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;  
        SceneManager.LoadScene(nextScene);
    }

}
