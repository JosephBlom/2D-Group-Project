using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float fireTime = 2f;
    [SerializeField] float bulletSpeed = 10f;

    float timer = 0f;

    void Start()
    {
        
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

        if (Input.GetButton("Fire1") && timer > fireTime)
        {
            shootDirection.Normalize();
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * bulletSpeed;
            bullet.GetComponent<Rigidbody2D>().angularVelocity = -360*2;
            Destroy(bullet, 3);
            timer = 0;
        }
    }
}

