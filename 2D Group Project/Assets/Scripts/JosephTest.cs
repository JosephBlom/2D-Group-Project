using UnityEngine;
using System.Collections;
using System;
using UnityEditor.Rendering;
using JetBrains.Annotations;
using UnityEngine.Rendering.Universal;

public class JosephTest : MonoBehaviour
{
    public Candle[] Candles;
    public bool complete = true;
    void Start()
    {
        Candles = FindObjectsOfType<Candle>();
    }

    public void CheckPuzzle()
    {
        complete = true;
        bool allLit = true; 
        for (int i = 0; i < Candles.Length; i++)
        {
            if (!Candles[i].Value == Candles[i].isLit)
            {
                complete = false;
            }
            if (!Candles[i].isLit)
            {
                allLit = false;
            }
        }
        if (!complete && allLit)
        {
            for(int i = 0;i < Candles.Length; i++)
            {
                Candles[i].isLit = false;
                Candles[i].GetComponent<Light2D>().enabled = false;
            }
        }
    }
}

