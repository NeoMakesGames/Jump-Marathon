using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;//being staic lets you call this from anywhere

    public AudioClip DeathSound = null; //this is your ham sound. Remember to link it in the editor

    void Start()
    {
        Instance = this;//this is very important!
    }
}