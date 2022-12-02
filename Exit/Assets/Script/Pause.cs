using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
public void Resume()
    {
            Time.timeScale = 1;
    }


    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game");

    }
}
   
