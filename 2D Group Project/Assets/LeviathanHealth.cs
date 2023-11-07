using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeviathanHealth : MonoBehaviour
{
    public float health;
    public ParticleSystem Blood;
    public LeviathanScript LevScript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lantern"))
        {
            health--;
        }
        if (health <= 0)
        {
            Blood.Play();
            LevScript.DegenerateLeviathan();
        }
    }
}
