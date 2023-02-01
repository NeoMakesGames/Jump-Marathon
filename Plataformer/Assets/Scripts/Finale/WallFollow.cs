using UnityEngine;
using System.Collections;

public class WallFollow : MonoBehaviour
{

    private GameObject player;       //Public variable to store a reference to the player game object


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    public float xOffset = 1.5f;

    public float smoothTime = 3f;
    //public Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        if(GameObject.FindWithTag("Player") != null)
            player = GameObject.FindWithTag("Player");

        if(player != null)
        {
            offset = transform.position - player.transform.position;
            offset = new Vector3(offset.x + xOffset, offset.y, offset.z);
        }
    }

    private void Update()
    {
        player = GameObject.FindWithTag("Player");
    }

    // LateUpdate is called after Update each frame
    void LateUpdate ()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if(player != null)
        {
            Vector3 targetPosition = player.transform.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothTime * Time.deltaTime);
        }
    }
}