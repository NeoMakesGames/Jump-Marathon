using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Screenshake : MonoBehaviour
{
    public static Screenshake Instance;
    private int currScene;
    public static bool shake = false;
    public float duration = 0.4f;
    public float magnitude = 0.2f;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        currScene = SceneManager.GetActiveScene().buildIndex;
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(shake)
        {
            StartCoroutine(Shake(duration, magnitude));
            shake = false;
        }
    }

    public IEnumerator Shake(float dur, float mag)
    {
        //Debug.Log("Shaking!");

        float elapsed = 0.0f;
        float duration = dur;
        float magnitude = mag;

        //yield return new WaitForSeconds(0.1f);

        Vector3 originalCamPos = Camera.main.transform.position;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + x,Camera.main.transform.position.y + y, originalCamPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        //Only reset pos if camera doesnt have CompleteCameraController script
        if(Camera.main.GetComponent<CompleteCameraController>() == null)
            Camera.main.transform.position = originalCamPos;
    }
}
