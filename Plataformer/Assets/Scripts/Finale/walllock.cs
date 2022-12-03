using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walllock : MonoBehaviour
{
    private float lockY;
    public GameObject primeEnemy;
    

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
            transform.position = new Vector3(primeEnemy.transform.position.x, lockY, transform.position.z);
        }

        if (transform.position.x != primeEnemy.transform.position.x)
        {
            transform.position = new Vector3(primeEnemy.transform.position.x, lockY, transform.position.z);
        }
    }
}
