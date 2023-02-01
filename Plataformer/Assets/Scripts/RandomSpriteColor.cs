using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpriteColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color color;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        color = new Color(Random.value, Random.value, Random.value, 1.0f);
        spriteRenderer.color = color;
    }
}
