using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunwayGenerator : MonoBehaviour
{
    public GameObject runwayObjectPrefab;
    public int runwayLength = 10;
    public float yVariability = 1;
    public float xVariability = 9;

    public GameObject finalObject;

    void Start()
    {
        //Generate runwayLength amount of runwayObjectPrefab at least xVariability apart with a random position between yVariability
        for (int i = 1; i < runwayLength+1; i++)
        {
            Vector3 runwayPosition = new Vector3(transform.position.x + xVariability * i, transform.position.y + Random.Range(-yVariability, yVariability), transform.position.z);
            Instantiate(runwayObjectPrefab, runwayPosition, transform.rotation);

            if(i == runwayLength)
            {
                Instantiate(finalObject, new Vector3(runwayPosition.x + 20, runwayPosition.y, runwayPosition.z), transform.rotation);
            }
        }
    }
}
