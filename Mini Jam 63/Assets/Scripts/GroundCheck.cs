using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public int type;

    Player player;
    Shooter enemy;

    void OnTriggerStay2D(Collider2D other)
    {
        if (transform.parent.GetComponent<Player>())
        {
            player = transform.parent.GetComponent<Player>();
            if (type == 0 && other.tag == "Ground" ||
                type == 0 && other.tag == "Victim")
            {
                player.jumpCount = 1;
                player.isGrounded = true;
            }
        }
        if (transform.parent.GetComponent<Shooter>())
        {
            enemy = transform.parent.GetComponent<Shooter>();

            if (type == 1 && other.tag == "Wall")
                enemy.dir = -enemy.dir;
            if (type == 2 && other.tag == "Player" ||
                type == 2 && other.tag == "Victim")
                enemy.shoot = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (transform.parent.GetComponent<Player>())
        {
            player = transform.parent.GetComponent<Player>();
            if (type == 0 && other.tag == "Ground" ||
                type == 0 && other.tag == "Victim")
                player.isGrounded = false;
        }
        if (transform.parent.GetComponent<Shooter>())
        {
            enemy = transform.parent.GetComponent<Shooter>();

            if (type == 2 && other.tag == "Player" ||
                type == 2 && other.tag == "Victim")
            {
                enemy.shoot = false;
                enemy.dir = enemy.currentDir;
            }
        }
    }
}
