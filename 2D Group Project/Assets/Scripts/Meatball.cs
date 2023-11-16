using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meatball : MonoBehaviour
{
    public Transform boss;
    public int damage;
    public float speed;
    public bool canHurt;
    public int intervals;
    public float SecondsFreezed;
    private void Start()
    {
        boss = FindAnyObjectByType<MainBoss>().gameObject.transform;
        Destroy(gameObject, 10);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().Health -= damage;
            Destroy(gameObject);
        }
        if (collision.CompareTag("Lantern"))
        {
            Vector3 Direction = Vector3.up * 10;
            if (boss != null)
            {
                canHurt = true;
                Direction = boss.position - transform.position;
            }
            GetComponent<Rigidbody2D>().velocity = Direction * speed;
        }
        if (collision.CompareTag("Boss") && canHurt)
        {
            boss.GetComponent<MainBoss>().health -= damage;
        }
    }
}
