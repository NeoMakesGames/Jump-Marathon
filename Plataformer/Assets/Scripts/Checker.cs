using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    public GameObject timer;

    // Start is called before the first frame update
    void Start()
    {
        if (!Timer.sw)
            Instantiate(timer);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Timer");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
    }
}
