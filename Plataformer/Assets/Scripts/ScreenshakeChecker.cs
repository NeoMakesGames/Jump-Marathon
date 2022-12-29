using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshakeChecker : MonoBehaviour
{
    public GameObject screenshaker;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Screen Shaker").Length == 0)
        {
            Instantiate(screenshaker);
        }
    }
}
