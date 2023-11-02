using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerShoot : MonoBehaviour
{
    public GameObject prefab;
    public float fireTime = 2f;
    public float bulletSpeed = 10f;
    public Animator animator;

    public float timer = 0f;
    public float startTime = 0f;
    float chargeTime = 0f;
    float bulletSpeedStart;

    void Start()
    {
        bulletSpeedStart = bulletSpeed;
        timer = 2;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            startTime = Time.time;
        }

        if (Input.GetButton("Fire1") && Time.time > fireTime)
        {
            chargeTime = Time.time - startTime;
        }

        if (Input.GetButtonUp("Fire1") && Time.time > fireTime)
        {
            fireTime = Time.time + timer;
            animator.Play("Throw");
            Invoke("SummonBullet", 0.1666666f);
        }
    }

    void SummonBullet()
    {
        Vector3 shootDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        shootDirection.z = 0f;
        GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = shootDirection.normalized * (bulletSpeed*(chargeTime + 1));
        bullet.GetComponent<Rigidbody2D>().angularVelocity = -720;
        Destroy(bullet, 5);
        chargeTime = 0f;
        bulletSpeed = bulletSpeedStart;
    }
}


