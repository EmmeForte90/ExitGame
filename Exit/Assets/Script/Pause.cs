using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public AudioMixer audioMixer;
public void Resume()
    {
            Time.timeScale = 1;
    }


    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        AudioManager.instance.StopMFX(1);
        AudioManager.instance.StopMFX(2);
        AudioManager.instance.PlayMFX(0);
        Time.timeScale = 1;

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game");

    }


    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);

    }

     public void SetSFX(float volume)
    {
        audioMixer.SetFloat("SFX", volume);

    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
   
