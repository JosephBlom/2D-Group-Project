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
        if(!collision.CompareTag("Enemy") && !collision.CompareTag("Player"))
        {
            Debug.Log("I Broke Lol");
            broken.Play();
            Destroy(gameObject);
        }
    }

}

