using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    public int Damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().Health -= Damage;
        }
        if (collision.CompareTag("Lantern"))
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
