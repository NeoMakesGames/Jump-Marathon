using System.Collections;
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
    public float minDistance = 4;

    public bool fixedTeleports = false;
    public Transform[] fixedTeleportLocations;

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

        if(!fixedTeleports)
        {
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

                // Teleport to a random location. Also make sure the x coordinate is less than the player's x coordinate.
                Vector2 randomPos = new Vector2(Random.Range(-1, teleportRadius * 1.5f), 6);

                transform.position = new Vector2(randomPos.x + player.position.x, randomPos.y + player.position.y);

                GameObject newGO = Instantiate(projectile, transform.position, Quaternion.identity);
                //Duplicate Scale
                newGO.transform.localScale *= Random.Range(1f, 2f);

                teleportTimer = teleportInterval;
            }

            teleportInterval -= Time.deltaTime * .01f;
        } else {
            //Teleport to the closest fixed teleport location to the player and instatiate particles. If it's already at the closest location, just shoot. Ignore variables like stoppingDistance and retreatDistance.
            for(int i = 0; i < fixedTeleportLocations.Length; i++)
            {
                if(Vector2.Distance(player.position, fixedTeleportLocations[i].position) < Vector2.Distance(transform.position, player.position))
                {
                    if(fixedTeleportLocations[i].position != transform.position)
                    {
                        // Emit particle effect before teleporting
                        Instantiate(teleportParticles, transform.position, Quaternion.identity, transform);

                        // Teleport to the closest fixed teleport location to the player
                        transform.position = fixedTeleportLocations[i].position;
                    }
                    else
                    {

                    }
                }
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

    IEnumerator wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
