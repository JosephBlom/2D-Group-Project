using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public int frequency = 1;
    int num;
    float flickerTime;
    public GameObject selectedLight;
    void Start()
    {
        reRun();
    }

    void Update()
    {

    }
    IEnumerator FlickerLights()
    {
        num = Random.Range(1, 100);
        Debug.Log(num);
        if (num <= frequency)
        {
            selectedLight.SetActive(false);
        }
        flickerTime = Random.Range(0.1f, 1f);
        yield return new WaitForSeconds(flickerTime);

        selectedLight.SetActive(true);
        reRun();
    }
    void reRun()
    {
        StartCoroutine(FlickerLights());
    }
}
