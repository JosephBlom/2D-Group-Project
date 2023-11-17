using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeTracker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Time: " + Time.time.ToString("0.00");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
