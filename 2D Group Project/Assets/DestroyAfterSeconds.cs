using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    public float seconds = 1;
    void Start()
    {
        Destroy(gameObject, seconds);
    }
}
