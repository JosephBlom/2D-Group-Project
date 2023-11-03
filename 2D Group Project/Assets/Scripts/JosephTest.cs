using UnityEngine;
using System.Collections;
using System;
using UnityEditor.Rendering;
using JetBrains.Annotations;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class JosephTest : MonoBehaviour
{
    public CandleLogic candleLogic;
    void Start()
    {
       candleLogic = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<CandleLogic>();
    }

    void Update()
    {
        gameObject.SetActive(candleLogic.complete);
    }
}

