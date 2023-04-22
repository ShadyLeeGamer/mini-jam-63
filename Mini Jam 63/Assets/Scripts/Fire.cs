using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    Victim[] victims;

    void Update()
    {
        victims = FindObjectsOfType<Victim>();

        if (transform.position.y >= -1.25f && victims.Length == 4)
            FindObjectOfType<GameGUI>().Win();
    }
}
