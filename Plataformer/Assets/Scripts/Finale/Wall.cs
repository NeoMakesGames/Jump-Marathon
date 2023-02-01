using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private GameObject player;
    private float previousPosition;
    private float currentPosition;
    public GameObject gO;
    private List<GameObject> gOs = new List<GameObject>();
    public int amount;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        previousPosition = player.transform.position.y;

        Spawn(currentPosition - 9, currentPosition + 9, amount, gO);
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = player.transform.position.y;
        float yDifference = currentPosition - previousPosition;
        if (Mathf.Abs(yDifference) >= 5)
        {
            Spawn(currentPosition - 9, currentPosition + 9, amount, gO);
            previousPosition = currentPosition;
        }

        while(gOs.Count > amount)
        {
            Destroy(gOs[0]);
            gOs.RemoveAt(0);
        }
    }

    void Spawn(float y1, float y2, int amount, GameObject gO)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject newGO = Instantiate(gO, new Vector3(transform.position.x - .5f, Random.Range(y1, y2), 0), Quaternion.identity);
            gOs.Add(newGO);
            newGO.transform.parent = gameObject.transform;
        }
    }
}
