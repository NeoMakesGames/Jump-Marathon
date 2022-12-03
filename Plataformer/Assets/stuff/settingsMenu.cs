using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class settingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;


    public void setVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void setFullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

     public void nextLevel ()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}