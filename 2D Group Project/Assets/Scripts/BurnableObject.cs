using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnableObject : Torch
{
    public GameObject fire;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Lantern"))
        {
            Instantiate(fire, transform.position, transform.rotation);
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Lantern"))
        {
            GameObject temp =Instantiate(fire, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject, Mathf.PI);
            Destroy(temp, Mathf.PI + Mathf.PI);
        }
    }
}
