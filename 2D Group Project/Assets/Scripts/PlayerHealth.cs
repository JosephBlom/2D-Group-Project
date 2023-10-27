using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    public int Health;
    public int MaxHealth;
    public TextMeshProUGUI text;
    private void Update()
    {
        if (text != null)
        {
            text.text = "Health: " + Health; 
        }
        if (Health <= 0)
        {
            Die();
        }
    }

    void Die()
    {

    }
}
