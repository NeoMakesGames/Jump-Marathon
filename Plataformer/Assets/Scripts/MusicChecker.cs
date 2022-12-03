using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChecker : MonoBehaviour
{
    public GameObject musicManager;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Music").Length == 0)
        {
            Instantiate(musicManager);
        }
    }
}
