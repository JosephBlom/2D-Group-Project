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
        if(on && !spawned){
            foreach (GameObject i in lights){
                i.SetActive(true);
            }
            foreach(GameObject i in spawnPoints)
            {
                GameObject temp = Instantiate(prefab,i.transform.position, Quaternion.identity);
                temp.GetComponent<EnemyMovement>().player = GameObject.FindGameObjectWithTag("Player");
                spawned = true; 
            }
        }
    }
}
