using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject ParticleSystem1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Player") || collision.CompareTag("Water"))
        {
            return;
        }
        GameObject ParticleSystem2 = Instantiate(ParticleSystem1, transform.position, Quaternion.identity);
        ParticleSystem2.GetComponent<ParticleSystem>().Play();
        ParticleSystem2.GetComponent<AudioSource>().Play();
        Destroy(gameObject);
    }
}
