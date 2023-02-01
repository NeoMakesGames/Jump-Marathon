using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSpriteColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color color;

    public bool randomizeEveryInterval;
    public float interval = 3;
    private float time;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        color = new Color(Random.value, Random.value, Random.value, 1.0f);
        spriteRenderer.color = color;
        time = interval;
    }

    void Update()
    {
        if(randomizeEveryInterval)
        {
            if(time <= 0)
            {
                color = new Color(Random.value, Random.value, Random.value, 1.0f);
                spriteRenderer.color = color;
                time = interval;
            }
            else
            {
                time -= Time.deltaTime;
            }
        }
    }
}
