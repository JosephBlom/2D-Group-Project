using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody2D))]

public class JosephTest : MonoBehaviour
{
    public GameObject ParticleSystem1;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Enemy") && !collision.CompareTag("Player"))
        {
            GameObject ParticleSystem2 = Instantiate(ParticleSystem1, transform.position, Quaternion.identity);
            ParticleSystem2.GetComponent<ParticleSystem>().Play();
            Destroy(ParticleSystem2, 5);
            Destroy(gameObject);
        }
    }

}

