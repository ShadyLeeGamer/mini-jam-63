using UnityEngine;

public class Shark : MonoBehaviour
{
    public bool canSeeFood;

    public float moveSpeed;

    public Transform shark;
    public Transform threatTXT;

    GameObject[] victims;

    void Update()
    {
        victims = GameObject.FindGameObjectsWithTag("Victim");

        threatTXT.position = new Vector2(shark.position.x, shark.position.y + 2);
        if (canSeeFood && FindClosestEnemy() != null)
        {
            shark.position = Vector2.MoveTowards(shark.position, FindClosestEnemy()
                                                               .transform.position, moveSpeed
                                                               * Time.deltaTime
                                                               * TimeScale.time);
        }

        if (FindClosestEnemy() != null)
        {
            if (FindClosestEnemy().transform.position.x <= shark.position.x)
                shark.eulerAngles = new Vector3(0, 180, 0);
            else
                shark.eulerAngles = new Vector3(0, 0, 0);
        }

        if (victims[0].transform.position.x < -7 &&
            victims[1].transform.position.x < -7 &&
            victims[2].transform.position.x < -7)
            FindObjectOfType<GameGUI>().Win();
    }

    void FixedUpdate()
    {
        canSeeFood = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.CompareTag("Victim"))
            canSeeFood = true;
    }

    public GameObject FindClosestEnemy()
    {
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject victim in victims)
        {
            Vector3 diff = victim.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = victim;
                distance = curDistance;
            }
        }
        return closest;
    }
}
