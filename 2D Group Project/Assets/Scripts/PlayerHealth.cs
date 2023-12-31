using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class PlayerHealth : MonoBehaviour
{
    static public int DeathCount = 0;
    public int Health;
    public int lastHealth;
    public int MaxHealth;
    public TextMeshProUGUI text;
    public ParticleSystem Blood;
    EnemyDamage Damage;
    private void Start()
    {
        lastHealth = Health;
    }
    private void Update()
    {
        if (Health < lastHealth)
        {
            lastHealth = Health;
            Blood.Play();
        }
        if (text != null)
        {
            text.text = "Health: " + Health; 
        }
        if (Health <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "BugEnemy")
        {
            Health -= 5;
        }
        else if(collision.gameObject.tag == "ZombieEnemy")
        {
            Health -= 8;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BugEnemy")
        {
            Health -= 5;
        }
    }

    void Die()
    {
        DeathCount++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
