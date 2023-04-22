using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public float mode;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (TimeScale.time > .3f || mode == 1)
        {
            if (other.transform.CompareTag("Player") ||
                other.transform.CompareTag("Victim"))
                Destroy(other.gameObject);
        }
    }
}
