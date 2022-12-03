﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Diagnostics;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public bool ended;
    public bool started;
    public int minutes;
    public int seconds;
    private float milliseconds;
    public static Timer sw;
    public bool exists;

    private void Start()
    {
        started = true;
        ended = false;

        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            UpdateTimer();
        }
    }

    public void UpdateTimer()
    {
        if (PlayerPrefs.HasKey("Milliseconds"))
            milliseconds = PlayerPrefs.GetFloat("Milliseconds");
        if (PlayerPrefs.HasKey("Seconds"))
            seconds = PlayerPrefs.GetInt("Seconds");
        if (PlayerPrefs.HasKey("Minutes"))
        {
            minutes = PlayerPrefs.GetInt("Minutes");
            if (seconds == 60)
                minutes--;
        }
    }

    private void Update()
    {
        if (started == true && ended == false)
        {
            milliseconds += Time.deltaTime;
            PlayerPrefs.SetFloat("Milliseconds", milliseconds);
        }
        else if (ended == true)
        {
            timerText.color = new Color(1, 0, 0, 1);
        }

        if (SceneManager.GetActiveScene().name == "Actual_End" || SceneManager.GetActiveScene().name == "Menu")
        {
            ended = true;
        }

        if (milliseconds >= 1)
        {
            seconds++;
            PlayerPrefs.SetInt("Seconds", seconds);
            milliseconds = 0;
        }

        if (seconds >= 60 && seconds != 0)
        {
            seconds = 0;
            minutes++;
            PlayerPrefs.SetInt("Minutes", minutes);
        }

        timerText.text = minutes.ToString() + ":" + seconds.ToString();
    }
}