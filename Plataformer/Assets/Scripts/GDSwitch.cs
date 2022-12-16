using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDSwitch : MonoBehaviour
{
    public GameObject switchedPlayer;
    public GameObject initialPlayer;
    private GameObject newInstance;
    private float ipX;
    private float xPlace;
    private float ipY;
    private int keysN;
    private int keysT;

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
            keysN = gameObject.GetComponent<keymanager>().keysNeeded;
            keysT = gameObject.GetComponent<keymanager>().totalKeys;

            Destroy(gameObject);

            Destroy(collision.gameObject);

           newInstance = Instantiate(switchedPlayer, new Vector2(xPlace, ipY), Quaternion.identity);
           newInstance.gameObject.GetComponent<keymanager>().keysNeeded = keysN;
           newInstance.gameObject.GetComponent<keymanager>().totalKeys = keysT;
        }
    }
}
