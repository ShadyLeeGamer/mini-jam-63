using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isGrounded;
    public bool playerSpotted;

    public float moveSpeed;
    public float stopDist;

    Player player;

    void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if(playerSpotted &&
           Vector2.Distance(transform.position, player.transform.position) > stopDist)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                                  new Vector2(player.transform.position.x, transform.position.y),
                                  moveSpeed * Time.deltaTime * TimeScale.time);
        }
    }
}
