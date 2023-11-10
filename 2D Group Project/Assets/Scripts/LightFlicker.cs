using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public int frequency = 1;
    int num;
    float flickerTime;
    public GameObject selectedLight;
    public bool powerOn = false;

    void Start()
    {
        powerOn = false;
        reRun();
    }

    void Update()
    {

    }

    IEnumerator FlickerLights()
    {
        if(!powerOn)
        {
            num = Random.Range(1, 100);
            if (num <= frequency)
            {
                selectedLight.SetActive(false);
            }
            flickerTime = Random.Range(0.1f, 1f);
            yield return new WaitForSeconds(flickerTime);

            selectedLight.SetActive(true);
        }
        reRun();
    }
    void reRun()
    {
        StartCoroutine(FlickerLights());
    }
}
