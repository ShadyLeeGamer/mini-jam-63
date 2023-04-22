using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    Player player;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<Player>();
            player.jumpCount = 1;
            player.moveSpeed = 4;
            player.jumpForce = .5f;
            other.GetComponent<Rigidbody2D>().gravityScale = .5f;
        }

        if (other.tag == "Victim")
        {
            other.GetComponent<Rigidbody2D>().gravityScale = .5f;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<Player>();
            player.jumpCount = 0;
            player.jumpForce = 20;
            player.moveSpeed = 7;
            other.GetComponent<Rigidbody2D>().gravityScale = 5;
        }

        if (other.tag == "Victim")
        {
            other.GetComponent<Rigidbody2D>().gravityScale = 5;
        }
    }
}
