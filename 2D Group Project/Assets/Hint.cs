using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{
    public TextMeshProUGUI text;
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
        if (ray)
        {
            switch (ray.transform.tag)
            {
                case "Sign":
                    text.text = ray.transform.GetComponent<Sign>().Text;
                    break;
            }
        }
        else
        {
            text.text = null;
        }
        
    }
}
