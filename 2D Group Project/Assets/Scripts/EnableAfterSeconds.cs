using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAfterSeconds : MonoBehaviour
{
    public GameObject Object;
    public float seconds;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("EnableGameObject", seconds);
    }

    // Update is called once per frame
    void EnableGameObject()
    {
        Object.SetActive(true);
    }
}
