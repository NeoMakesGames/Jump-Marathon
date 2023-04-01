using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    private float moveInput;
    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int extraJumps;
    public int extraJumpsValue;
    private GameObject eyes;
    private Color jumpColor;
    public Material trailMaterial;

    int scene;
    int currentlevel;

    // Box collider alternative settings
    // Offset x: -0.001676202 | Offset y: 0.006846666
    // Size x: 0.9765337 | Size y: 0.9863067

    private void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        eyes = GameObject.Find("Eyes");
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    private void Update()
    {
        GetPlayerInputs();
        jumpColor = new Color(0, .8f * ((float)extraJumps / (float)extraJumpsValue), 1, 1);
        jumpColor.g = Mathf.Lerp(0.8f, 0f, (float)(extraJumpsValue - extraJumps) / (float)extraJumpsValue);
        trailMaterial.SetColor("_Color", jumpColor);
        eyes.GetComponent<SpriteRenderer>().color = Color.Lerp(eyes.GetComponent<SpriteRenderer>().color, jumpColor, Time.deltaTime * 5f);;
        float maxTrailTime = 0.25f;
        float minTrailTime = 0f;
        float targetTrailTime = Mathf.Lerp(minTrailTime, maxTrailTime, (float)extraJumps / extraJumpsValue);
        float trailLerpTime = 5f; // Adjust this to control the speed of the transition
        float currentTrailTime = Mathf.Lerp(gameObject.GetComponent<TrailRenderer>().time, targetTrailTime, Time.deltaTime * trailLerpTime);
        gameObject.GetComponent<TrailRenderer>().time = currentTrailTime;
    }

    private void GetPlayerInputs ()
    {
        if (moveInput < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (moveInput > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpforce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpforce;
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton0) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpforce;
            extraJumps--;
        }

        else if (Input.GetKeyDown(KeyCode.JoystickButton0) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpforce;
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton1) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpforce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.JoystickButton1) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpforce;
        }

        if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpforce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpforce;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpforce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpforce;
        }

        /*
        if (Input.GetKeyDown(KeyCode.End))
        {
            scene = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadSceneAsync(scene);
            currentlevel = SceneManager.GetActiveScene().buildIndex + 1;
            PlayerPrefs.SetInt("CurrentLevel", currentlevel);
        } 
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            Screenshake.shake = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //AudioManager.Instance.DeathSound.LoadAudioData();
        }
    }
}