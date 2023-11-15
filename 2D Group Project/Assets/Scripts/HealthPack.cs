using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public float Timer = 2;
    public Transform[] SpawningSpots;
    float nextTimeToFire = 0;
    public SpriteRenderer spriteRend;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PlayerHealth>().Health <= 90 && Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + Timer;
                collision.GetComponent<PlayerHealth>().Health += 10;
                if(SpawningSpots.Length > 0)
                {
                    transform.position = SpawningSpots[Random.Range(0, SpawningSpots.Length)].position;
                }
            }
        }
    }

    private void Update()
    {
        spriteRend.enabled = Time.time > nextTimeToFire;
    }
}
