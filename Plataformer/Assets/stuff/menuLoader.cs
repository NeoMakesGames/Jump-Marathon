using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuLoader : MonoBehaviour
{
    private void Start()
    {
        //If scene name == DemoScene then if the game isnt fullscreen make it fullscreen
        if (SceneManager.GetActiveScene().name == "DemoScene")
        {
            if (!Screen.fullScreen)
            {
                Screen.fullScreen = true;
            }
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
