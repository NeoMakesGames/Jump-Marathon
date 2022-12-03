using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public GameObject timer;
    int currentLevel;

    private void Start()
    {
        if(GameObject.FindGameObjectWithTag("Browser"))
            Destroy(GameObject.FindGameObjectWithTag("Browser"));
    }

    public void PlayGame ()
    {
        PlayerPrefs.SetInt("CurrentLevel", 1);
        PlayerPrefs.SetFloat("Milliseconds", 0);
        PlayerPrefs.SetInt("Seconds", 0);
        PlayerPrefs.SetInt("Minutes", 0);

        // Lanza la escena siguiente a la del menu de acuerdo al build index
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void BrowseFilesForCustomLevel()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    public void ContinueGame()
    {
        //lee el nivel guardado en PlayerPrefs
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            currentLevel = PlayerPrefs.GetInt("CurrentLevel");
            SceneManager.LoadSceneAsync(currentLevel--);
        }
        else
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void QuitGame ()
    {
        Debug.Log("We just left the game!");
        Application.Quit();
    }

    public void PlayGame2()
    {
        PlayerPrefs.SetInt("CurrentLevel", SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
