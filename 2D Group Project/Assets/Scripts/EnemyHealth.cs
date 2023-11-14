using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject prefab;
    public int BugHealth = 1;
    public int ZombieHealth = 2;
    int health;

    void Start()
    {
        if (gameObject.CompareTag("BugEnemy"))
        {
            health = BugHealth;
        }
        else
        {
            health = ZombieHealth;
        }
    }

    private void Update()
    {
        if(health <= 0)
        {
            int num = Random.Range(1, 100);
            if(num <= 5)
            {
                Instantiate(prefab, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Lantern")
        {
            health--;
        }
    }
}
