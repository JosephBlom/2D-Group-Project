using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{
    public TextMeshProUGUI text;
    public RectTransform backgroundImage;
    void Update()
    {
        backgroundImage.sizeDelta = text.rectTransform.sizeDelta;
        var mousePos = Input.mousePosition;
        mousePos.z = 10;
        RaycastHit2D ray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePos), Vector3.forward);
        if (ray)
        {
            switch (ray.transform.tag)
            {
                case "Sign":
                    string tempText = string.Empty;
                    foreach (string string1 in ray.transform.GetComponent<Sign>().Text.Split("/n"))
                    {
                        tempText += string1;
                        tempText += "\n";
                    }
                    text.text = tempText;
                    text.fontSize = ray.transform.GetComponent<Sign>().FontSize;
                    break;
            }
        }
        else
        {
            text.text = null;
        }
        
    }
}
