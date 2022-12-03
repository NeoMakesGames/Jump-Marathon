using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDSwitch : MonoBehaviour
{
    public GameObject switchedPlayer;
    public GameObject initialPlayer;
    private float ipX;
    private float xPlace;
    private float ipY;

    // Update is called once per frame
    void Update()
    {
        ipX = initialPlayer.transform.position.x;
        xPlace = ipX + 0.3f;
        ipY = initialPlayer.transform.position.y;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerSwitch")
        {
            Destroy(gameObject);

            Destroy(collision.gameObject);

           Instantiate(switchedPlayer, new Vector2(xPlace, ipY), Quaternion.identity);
        }
    }
}
