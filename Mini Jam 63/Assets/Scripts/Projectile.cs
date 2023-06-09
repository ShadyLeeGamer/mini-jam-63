﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(Vector2.right * TimeScale.time * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall" ||
            other.tag == "Player" ||
            other.tag == "Victim")
        {
            if (other.tag == "Player" ||
                other.tag == "Victim")
                Destroy(other.gameObject);

            Destroy(gameObject);
        }
    }
}
