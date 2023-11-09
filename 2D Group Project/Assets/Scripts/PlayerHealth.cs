using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int Health;
    public int lastHealth;
    public int MaxHealth;
    public TextMeshProUGUI text;
    public ParticleSystem Blood;
    private void Start()
    {
        lastHealth = Health;
    }
    private void Update()
    {
        if (Health != lastHealth)
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
        if(collision.gameObject.tag == "Enemy")
        {
            Health -= 5;
        }
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
