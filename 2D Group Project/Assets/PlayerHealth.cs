using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int Health;
    public int MaxHealth;
    public Text text;
    private void Update()
    {
        text.text = Health.ToString();
        if (Health <= 0)
        {
            Die();
        }
    }

    void Die()
    {

    }
}
