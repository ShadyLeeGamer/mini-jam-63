using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    bool move;

    public float delay;
    public float moveSpeed;

    void Start()
    {
        StartCoroutine(Timing());
    }

    void Update()
    {
        if (move)
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime * TimeScale.time);

        if (FindObjectOfType<Victim>() &&
           FindObjectOfType<Player>() &&
           transform.position.x <= -19.89f)
        {
            FindObjectOfType<GameGUI>().Win();
            Destroy(gameObject);
        }
    }

    IEnumerator Timing()
    {
        yield return new WaitForSeconds(delay);
        move = true;
    }
}
