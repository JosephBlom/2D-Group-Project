using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public bool on = false;
    public GameObject prefab;
    public GameObject[] lights;
    public GameObject[] spawnPoints;
    bool spawned = false;

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
            if (!spawned)
            {
                foreach (GameObject i in spawnPoints)
                {
                    Instantiate(prefab, i.transform.position, Quaternion.identity);
                    spawned = true;
                }
            }
        }
    }
}
