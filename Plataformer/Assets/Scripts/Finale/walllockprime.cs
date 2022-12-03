using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walllockprime : MonoBehaviour
{
    private float lockY;

    // Start is called before the first frame update
    void Start()
    {
        lockY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y != lockY)
        {
            transform.position = new Vector3(transform.position.x, lockY, transform.position.z);
        }
    }
}
