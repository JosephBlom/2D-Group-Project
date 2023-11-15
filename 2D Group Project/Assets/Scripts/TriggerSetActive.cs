using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TriggerSetActive : MonoBehaviour
{
    public GameObject[] TurnOff;
    public GameObject[] TurnOn;
    public bool editTrigger = false;
    public bool OnTriggerEnter = true;
    public bool runTrigger = true;
    public bool stopOrGo = false;
    public GameObject SelectedTrigger;
    TriggerSetActive triggerScript;

    void Start()
    {
        triggerScript = SelectedTrigger.GetComponent<TriggerSetActive>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(runTrigger)
        {
            if(editTrigger)
            {
                triggerScript.runTrigger = stopOrGo;
            }
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
        
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(runTrigger)
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
}
