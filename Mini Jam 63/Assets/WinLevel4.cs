using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLevel4 : MonoBehaviour
{
    GameObject[] victims;
    void Update()
    {
        victims = GameObject.FindGameObjectsWithTag("Victim");

        if (victims[0].transform.position.x < -13 &&
            victims[1].transform.position.x < -13)
            FindObjectOfType<GameGUI>().Win();
    }
}
