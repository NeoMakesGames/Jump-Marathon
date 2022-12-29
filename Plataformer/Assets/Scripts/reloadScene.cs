using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reloadScene : MonoBehaviour
{
    public bool isColliseumVariant = false;
    private int currentlevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isColliseumVariant)
        {
            Screenshake.shake = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            AudioManager.Instance.DeathSound.LoadAudioData();
        }
        if (collision.CompareTag("Player") && isColliseumVariant)
        {
            Screenshake.shake = true;
            PlayerPrefs.SetInt("CurrentLevel", SceneManager.GetActiveScene().buildIndex - 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            AudioManager.Instance.DeathSound.LoadAudioData();
        }
    }
}