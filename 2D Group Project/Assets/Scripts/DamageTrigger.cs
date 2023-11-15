using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    public Vector2 ForceDirection;
    public float ForceAmount = 1;
    public int Damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().Health -= Damage;
            collision.GetComponent<Rigidbody2D>().velocity += ForceDirection * ForceAmount;
        }
    }
}
