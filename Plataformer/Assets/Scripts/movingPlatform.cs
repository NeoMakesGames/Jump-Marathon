using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    public float speed;
    public string direction;
    public float distanceToMove;
    public Vector3 startPosition;
    public bool reachedDestination;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(direction.ToLower() == "left")
        {
            if(!reachedDestination)
            {
                if(transform.position.x > startPosition.x - distanceToMove)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(startPosition.x - distanceToMove, transform.position.y, transform.position.z), speed * Time.deltaTime);
                }
                else
                {
                    reachedDestination = true;
                }
            } else if(reachedDestination)
            {
                if(transform.position.x < startPosition.x)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(startPosition.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
                }
                else
                {
                    reachedDestination = false;
                }
            }
        }
        else if (direction.ToLower() == "right")
        {
            if (!reachedDestination)
            {
                if (transform.position.x < startPosition.x + distanceToMove)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(startPosition.x + distanceToMove, transform.position.y, transform.position.z), speed * Time.deltaTime);
                }
                else
                {
                    reachedDestination = true;
                }
            }
            else if (reachedDestination)
            {
                if (transform.position.x > startPosition.x)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(startPosition.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
                }
                else
                {
                    reachedDestination = false;
                }
            }
        } else if (direction.ToLower() == "up")
        {
            if (!reachedDestination)
            {
                if (transform.position.y < startPosition.y + distanceToMove)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, startPosition.y + distanceToMove, transform.position.z), speed * Time.deltaTime);
                }
                else
                {
                    reachedDestination = true;
                }
            }
            else if (reachedDestination)
            {
                if (transform.position.y > startPosition.y)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, startPosition.y, transform.position.z), speed * Time.deltaTime);
                }
                else
                {
                    reachedDestination = false;
                }
            }
        }/* else if (direction.ToLower() == "down")
        {
            if (!reachedDestination)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, startPosition.y - distanceToMove, transform.position.z), speed * Time.deltaTime);
                Debug.Log(startPosition.y - distanceToMove);
                if (transform.position.y == startPosition.y - distanceToMove)
                {
                    Debug.Log("reached destination");
                    reachedDestination = true;
                }
            } else if (reachedDestination)
            {

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, startPosition.y, transform.position.z), speed * Time.deltaTime);
                if(transform.position.y == startPosition.y)
                {
                    Debug.Log("Came back to start");
                    reachedDestination = false;
                }
            }
        }*/
    }
}
