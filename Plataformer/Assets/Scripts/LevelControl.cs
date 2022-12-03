using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
// using System.IO;
// using System.Runtime.Serialization.Formatters.Binary;

public class LevelControl : MonoBehaviour
{
    public bool FreeEnemyTwist = false;

    public bool dontWork = false;

    int currentlevel = 0;

    private float portalWaitTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && dontWork == false)
        {
            // guarda en PlayerPrefs el nivel actual
            if (SceneManager.GetActiveScene().name != "Actual_End" || SceneManager.GetActiveScene().name != "Menu")
            {
                currentlevel = SceneManager.GetActiveScene().buildIndex + 1;
                PlayerPrefs.SetInt("CurrentLevel", currentlevel);
            }
            else
            {
                PlayerPrefs.SetInt("CurrentLevel", 1);
            }

            // For advancing to the next level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (collision.CompareTag("Enemy") && FreeEnemyTwist == true)
        {
            if (dontWork)
            {

            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
    }
    // Funciones para grabar y leer archivos de texto guardados en directorio C:\Users\tomas\AppData\LocalLow\DefaultCompanyName\Jump marathon
    // For level saving (used https://answers.unity.com/questions/1300019/how-do-you-save-write-and-load-from-a-file.html)
