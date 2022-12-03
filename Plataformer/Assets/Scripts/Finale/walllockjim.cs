using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walllockjim : MonoBehaviour
{
    private float lockY;
    public GameObject primeEnemy;
    private float jimX;
    

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

        jimX = primeEnemy.transform.position.x - 2.5f;

        if (transform.position.x != jimX)
        {
            transform.position = new Vector3(jimX, lockY, transform.position.z);
        }
    }
}
