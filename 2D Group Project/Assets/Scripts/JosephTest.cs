using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody2D))]

public class JosephTest : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float fireTime = 2f;
    [SerializeField] float bulletSpeed = 10f;

    float timer = 0f;
    float chargeTime = 0f;
    float bulletSpeedStart;
    float multFactor;

    void Start()
    {
        bulletSpeedStart = bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        Vector3 shootDirection = Input.mousePosition;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection.z = 0f;
        shootDirection -= transform.position;

        timer += Time.deltaTime;

        if (Input.GetButton("Fire1"))
        {
            chargeTime += Time.deltaTime;
            if(multFactor < 3)
            {
                multFactor += (chargeTime);
            }
            else
            {
                multFactor = 3;
            }
        }

        if (Input.GetButtonUp("Fire1") && timer > fireTime)
        {
            multFactor += 1;
            bulletSpeed *= multFactor;
            Debug.Log(bulletSpeed);
            shootDirection.Normalize();
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * bulletSpeed;
            Destroy(bullet, 3);
            timer = 0;
            chargeTime = 0f;
            multFactor = 0;
            bulletSpeed = bulletSpeedStart;
        }
    }
}

