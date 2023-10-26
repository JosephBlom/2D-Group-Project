using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Candle : Torch
{
    public Sprite litSprite;
    public Sprite notLitSprite;
    public bool Value;
    public bool isLit;
    // Start is called before the first frame update
    void Start()
    {
        isLit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLit)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = litSprite;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = notLitSprite;
        }
    }


    public override void OnTorchTouched()
    {
        isLit = true;
        GetComponent<Light2D>().enabled = isLit;
        GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<JosephTest>().CheckPuzzle();
    }
}
