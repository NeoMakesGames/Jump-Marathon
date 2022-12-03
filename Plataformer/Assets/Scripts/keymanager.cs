using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keymanager : MonoBehaviour
{

    public int keysNeeded = 0;

    private int totalKeys = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Scene scene = SceneManager.GetActiveScene();

        if (collision.tag == "Key")
        {
            totalKeys = totalKeys + 1;

            Destroy(collision.gameObject);
        }

        if (collision.tag == "Objective")
        {
            if (totalKeys >= keysNeeded)
            {
                // guarda en PlayerPrefs el nivel actual
                if (scene.name != "Actual End" || scene.name != "Menu")
                {
                    PlayerPrefs.SetInt("CurrentLevel", SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    PlayerPrefs.SetInt("CurrentLevel", 1);
                }

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
