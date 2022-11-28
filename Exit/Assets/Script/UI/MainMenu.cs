using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public string startScene, continueScene;
    public float Timelife;
    public GameObject opzioni;
    public GameObject continueButton;
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public Dropdown resolutionDropdown;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
         string option = resolutions[i].width + "x" + resolutions[i].height;
        options.Add(option);

        if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
        {
            currentResolutionIndex = i;
        }

        }

        resolutionDropdown.ClearOptions();
        resolutionDropdown.value = currentResolutionIndex;
        //resolutionDropdown.RefreshValue();
        resolutionDropdown.AddOptions(options);



        if(PlayerPrefs.HasKey(startScene + "_unlocked"))
        {
            continueButton.SetActive(true);
        }
        else
        {
            continueButton.SetActive(false);
        }

    }

public void SetResolution(int resolutionIndex)
{
    Resolution resolution = resolutions[resolutionIndex];

    Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
}

    public void StartGame()
    {
        StartCoroutine(fade());
       

    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(continueScene);
    }

    public void Options()
    {
        opzioni.gameObject.SetActive(true);
    }
    public void ExitOptions()
    {
        opzioni.gameObject.SetActive(false);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);

    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

IEnumerator fade()
    {
        yield return new WaitForSeconds(Timelife);
SceneManager.LoadScene(startScene);

        PlayerPrefs.DeleteAll();    }
 

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game");

    }

}
