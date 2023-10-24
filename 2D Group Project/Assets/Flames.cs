using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : Torch
{
    public GameObject FlamesObject;

    public void Start()
    {
        FlamesObject.SetActive(false);
    }

    public override void OnTorchTouched()
    {
        FlamesObject.SetActive(true);
    }
}
