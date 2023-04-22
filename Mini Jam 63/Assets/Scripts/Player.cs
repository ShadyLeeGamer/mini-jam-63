using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isGrounded;
    public bool isJumping;
    public bool changingTime;

    public int oppositeTime;
    public int currentTime = 1;
    public int HP = 1;
    public int jumpCount = 1;

    public float moveSpeed;
    public float jumpForce;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    public float accelerationTimeAirborne, accelerationTimeGrounded;
    public float stopTime;
    public float stopSpeed;
    public float delay;
    public float time;

    Rigidbody2D rb;

    AudioSource audio;

    GameView gameView;

    public ColorManager colorManager;
    GameGUI gameManager;

    public static event Action StopTimeAction;

    void Awake()
    {
        gameManager = FindObjectOfType<GameGUI>();
        gameView = FindObjectOfType<GameView>();
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        TimeScale.time = 1;
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"),
                                    Input.GetAxisRaw("Vertical"));

        if (input.y > 0 && jumpCount > 0)
            Jump();

        if (!gameManager.gameOver)
        {
            rb.velocity = new Vector2(input.x * moveSpeed, rb.velocity.y);

            if (TimeScale.time == 1 && !changingTime && Input.GetKeyDown(KeyCode.Space))
                StartCoroutine(StopTime());
        }
        else
            rb.velocity = Vector2.zero;

        /*if (rb.velocity.y < 0)
            rb.gravityScale = fallMultiplier;
        else if (rb.velocity.y > 0 && input.y == 1)
            rb.gravityScale = lowJumpMultiplier;
        else
            rb.gravityScale = 5f;*/

        time = TimeScale.time;

        if (changingTime)
            TimeTransitioning();
        if (stopTime > 1)
            stopTime = 1;
        else if (stopTime < 0)
            stopTime = 0;
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumpCount = 0;
    }

    IEnumerator StopTime()
    {
        currentTime = Convert.ToInt32(TimeScale.time);
        oppositeTime = Convert.ToInt32(1 - TimeScale.time);

        StopTimeAction?.Invoke();

        audio.Play();

        changingTime = true;
        yield return new WaitForSeconds(stopSpeed * 10);
        changingTime = false;

        yield return new WaitForSeconds(delay);

        currentTime = Convert.ToInt32(TimeScale.time);
        oppositeTime = Convert.ToInt32(1 - TimeScale.time);

        changingTime = true;
        yield return new WaitForSeconds(stopSpeed * 10);
        changingTime = false;
    }

    void TimeTransitioning()
    {
        TimeScale.time = Mathf.Lerp(0, 1, stopTime);

        GetComponent<SpriteRenderer>().color = colorManager.playerCol[currentTime];

        GameObject[] victims = GameObject.FindGameObjectsWithTag("Victim");
        for (int i = 0; i < victims.Length; i++)
        {
            victims[i].GetComponent<Rigidbody2D>().gravityScale = Mathf.Lerp(0, 5, stopTime);
            victims[i].GetComponent<SpriteRenderer>().color = colorManager.victimCol[currentTime];
        }

        GameObject[] threats = GameObject.FindGameObjectsWithTag("Threat");

        if (threats.Length > 0)
        {
            for (int i = 0; i < victims.Length; i++)
                threats[i].GetComponent<SpriteRenderer>().color = colorManager.threatCol[currentTime];
        }

        GameObject[] grounds = GameObject.FindGameObjectsWithTag("Ground");
        for (int i = 0; i < grounds.Length; i++)
            if(grounds[i].GetComponent<SpriteRenderer>())
                grounds[i].GetComponent<SpriteRenderer>().color = colorManager.obstacleCol[currentTime];

        gameView.camera.backgroundColor = colorManager.BGCol[currentTime];

        if (currentTime == 1)
            stopTime -= Time.deltaTime * stopSpeed;
        else if (currentTime == 0)
            stopTime += Time.deltaTime * stopSpeed * 2;
    }
}
