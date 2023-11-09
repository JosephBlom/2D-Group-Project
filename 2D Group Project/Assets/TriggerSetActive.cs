using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TriggerSetActive : MonoBehaviour
{
    public GameObject[] TurnOff;
    public GameObject[] TurnOn;
    public bool OnTriggerEnter = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!OnTriggerEnter) { return; }
        if (collision.CompareTag("Player"))
        {
            foreach(GameObject g in TurnOff)
            {
                g.SetActive(false);
            }
            foreach (GameObject g in TurnOn)
            {
                g.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (OnTriggerEnter) { return; }
        if (collision.CompareTag("Player"))
        {
            foreach (GameObject g in TurnOff)
            {
                g.SetActive(false);
            }
            foreach (GameObject g in TurnOn)
            {
                g.SetActive(true);
            }
        }
    }
}
