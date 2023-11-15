using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meatball : MonoBehaviour
{
    public Transform boss;
    public int damage;
    public float speed;
    public bool canHurt;
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
            StartCoroutine(freezeFrame());
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

    IEnumerator freezeFrame()
    {
        Time.timeScale = 0.1f;
        yield return new WaitForSecondsRealtime(0.025f);
        Time.timeScale = 0.15f;
        yield return new WaitForSecondsRealtime(0.025f);
        Time.timeScale = 0.2f;
        yield return new WaitForSecondsRealtime(0.025f);
        Time.timeScale = 0.25f;
        yield return new WaitForSecondsRealtime(0.025f);
        Time.timeScale = 0.3f; 
        yield return new WaitForSecondsRealtime(0.025f);
        Time.timeScale = 0.35f;
        yield return new WaitForSecondsRealtime(0.025f);
        Time.timeScale = 0.4f;
        yield return new WaitForSecondsRealtime(0.025f);
        Time.timeScale = 0.45f;
        yield return new WaitForSecondsRealtime(0.025f);
        Time.timeScale = 0.5f;
        yield return new WaitForSecondsRealtime(0.025f);
        Time.timeScale = 0.55f;
        yield return new WaitForSecondsRealtime(0.025f);
        Time.timeScale = 0.6f;
        yield return new WaitForSecondsRealtime(0.025f);
        Time.timeScale = 0.65f;
        yield return new WaitForSecondsRealtime(0.025f);
        Time.timeScale = 0.7f;
        yield return new WaitForSecondsRealtime(0.025f);
        Time.timeScale = 0.75f;
        yield return new WaitForSecondsRealtime(0.025f);
        Time.timeScale = 0.8f;
        yield return new WaitForSecondsRealtime(0.025f);
        Time.timeScale = 0.85f;
        yield return new WaitForSecondsRealtime(0.025f);
        Time.timeScale = 0.9f;
        yield return new WaitForSecondsRealtime(0.025f);
        Time.timeScale = 0.95f;
        yield return new WaitForSecondsRealtime(0.025f);
        Time.timeScale = 1;
    }
}
