﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreFinaleJim : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float timeBtwShots;
    public float startTimeBtwShots;
    public float teleportInterval; // interval between teleports
    public float teleportRadius; // radius within which to teleport
    public GameObject teleportParticles; // particle system to emit before teleporting

    public GameObject projectile;
    private Transform player;

    private float teleportTimer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        teleportTimer = teleportInterval;
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;

        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        teleportTimer -= Time.deltaTime;
        if (teleportTimer <= 0)
        {
            // Emit particle effect before teleporting
            Instantiate(teleportParticles, transform.position, Quaternion.identity, transform);

            // Teleport to a random location
            Vector2 randomPos = (Random.insideUnitCircle * teleportRadius) + (Vector2)player.position;
            while (Vector2.Distance(randomPos, player.position) < stoppingDistance + 1.5f) {
                randomPos = (Random.insideUnitCircle * teleportRadius) + (Vector2)player.position;
            }
            transform.position = new Vector3(randomPos.x, randomPos.y, 0);

            //Debug.Log("Teleported to " + (player.position.x - randomPos.x) * -1 + ", " + (player.position.y - randomPos.y) * -1);

            transform.position = new Vector3(randomPos.x, randomPos.y, 0);


            teleportTimer = teleportInterval;
        }

        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;

        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
