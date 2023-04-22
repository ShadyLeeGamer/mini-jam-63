using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public bool shoot;

    public Transform threatTXT;
    public Transform firePoint;

    public GameObject projectile;

    public int dir;
    [HideInInspector] public int currentDir;

    public float moveSpeed;
    public float shootSpeed;
    public float recoil;
    float nextTimeToShoot;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        threatTXT.position = new Vector2 (transform.position.x, transform.position.y + 1.5f);

        Vector2 move = new Vector2(dir * TimeScale.time * moveSpeed, rb.velocity.y);
        rb.velocity = move;

        if (dir > 0)
            transform.eulerAngles = new Vector2(0, 0);
        if (dir < 0)
            transform.eulerAngles = new Vector2(0, 180);

        if(shoot && TimeScale.time == 1)
        {
            dir = 0;

            if (Time.time >= nextTimeToShoot)
            {
                firePoint.localEulerAngles = new Vector3(0, firePoint.rotation.y,
                                                            Random.Range(-recoil, recoil));
                Instantiate(projectile, firePoint.position, firePoint.rotation);

                nextTimeToShoot = Time.time + 1f / shootSpeed;
            }
        }
        else
            currentDir = dir;
    }
}
