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
            Destroy(otherEnemy);
            Destroy(gameObject);
            Instantiate(giant, new Vector2 (GiantX, GiantY), Quaternion.identity);
            Instantiate(plataform, new Vector2(levelProgressionX, levelProgressionY), Quaternion.identity);
            arrow.SetActive(true);
            extraplat.SetActive(true);
        }
    }
}
