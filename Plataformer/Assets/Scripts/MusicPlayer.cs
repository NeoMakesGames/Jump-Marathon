using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip musicForLevel;
    private AudioSource musicManager;

    void Start()
    {
        musicManager = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        if(musicManager.clip != musicForLevel)
        {
            musicManager.clip = musicForLevel;
            musicManager.Play();
        }
    }
}
