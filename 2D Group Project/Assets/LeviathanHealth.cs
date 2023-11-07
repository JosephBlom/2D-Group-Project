using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeviathanHealth : MonoBehaviour
{
    public float health;
    public ParticleSystem Blood;
    public LeviathanScript LevScript;
    public Slider Health;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lantern"))
        {
            health--;
            Health.value = health;
        }
        if (health <= 0)
        {
            Blood.Play();
            LevScript.DegenerateLeviathan();
        }
    }
}
