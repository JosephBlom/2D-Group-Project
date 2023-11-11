using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public bool on = false;
    public GameObject[] lights;

    void Start()
    {
        lights = GameObject.FindGameObjectsWithTag("LightsBasement");
        foreach(GameObject i in lights){
            i.SetActive(false);
        }
    }

    void Update()
    {
        if(on){
            foreach (GameObject i in lights){
                i.SetActive(true);
            }
        }
    }
}
