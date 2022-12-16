using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantSpawner : MonoBehaviour
{

    public float GiantX;
    public float GiantY;

    public float levelProgressionX;
    public float levelProgressionY;

    public GameObject giant;
    public GameObject otherEnemy;
    public GameObject plataform;
    public GameObject arrow, extraplat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(otherEnemy != null)
                Destroy(otherEnemy);

            if(giant != null)
                Instantiate(giant, new Vector2 (GiantX, GiantY), Quaternion.identity);

            if(plataform != null)
                Instantiate(plataform, new Vector2(levelProgressionX, levelProgressionY), Quaternion.identity);

            if(arrow != null)
                arrow.SetActive(true);

            if(extraplat != null)
                extraplat.SetActive(true);

            Destroy(gameObject);
        }
    }
}
