using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    public Vector2 interval;
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private float timer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        timer = Random.Range(interval.x * 0.1f, interval.y * 0.1f);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
            timer = Random.Range(interval.x * 0.1f, interval.y * 0.1f);
        }
    }
}
