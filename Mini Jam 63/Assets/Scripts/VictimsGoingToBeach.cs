using UnityEngine;

public class VictimsGoingToBeach : MonoBehaviour
{
    public Transform targetPos;

    public float moveSpeed;

    void Update()
    {
        if(!FindObjectOfType<GameGUI>().gameOver)
            transform.position = Vector2.MoveTowards(transform.position, targetPos.position
                                                                       , moveSpeed * Time.deltaTime
                                                                                   * TimeScale.time);
    }
}
