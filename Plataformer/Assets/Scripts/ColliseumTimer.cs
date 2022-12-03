using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ColliseumTimer : MonoBehaviour
{
    public float timerTime;
    public bool spawnerDone;
    public Text timer;

    private void Update()
    {
        int privateSpawnTime = System.Convert.ToInt32(timerTime);
        timer.text = privateSpawnTime.ToString();

        if (GameObject.FindGameObjectWithTag("Player"))
        {
            timerTime -= Time.deltaTime;
            if (timerTime < 0)
            {
                spawnerDone = true;
            }
        }

        if (spawnerDone)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
