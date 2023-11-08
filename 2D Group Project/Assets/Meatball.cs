using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meatball : MonoBehaviour
{
    public int damage;
    public float attackDelay;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().Health -= damage;
        }
    }
}
