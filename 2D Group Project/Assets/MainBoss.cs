using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBoss : MonoBehaviour
{
    public Transform Player;
    public GameObject MeatBall;
    public Vector3 Offset;
    public bool Attack1;
    public float attackDelay;
    float nextTimeToFire;
    public float directionX;
    public float speed;
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    void Attack()
    {
        Instantiate(MeatBall, transform.position + Offset, Quaternion.identity);
    }

    void Update()
    {
        if (Attack1)
        {
            Attack1 = false;
            Attack();
        }
        if (Time.time > nextTimeToFire)
        {
            nextTimeToFire = Time.time + attackDelay;
            Attack();
        }
        directionX = Player.position.x - transform.position.x;

        transform.position += new Vector3(directionX * Time.deltaTime * speed, 0, 0);
    }
}
