using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody2D))]

public class JosephTest : MonoBehaviour
{

    [SerializeField] ParticleSystem broken;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Enemy" || collision.gameObject.tag != "Player")
        {
            broken.Play();
            Destroy(gameObject);
        }
    }

}

