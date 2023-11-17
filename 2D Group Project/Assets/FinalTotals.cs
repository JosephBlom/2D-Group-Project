using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class FinalTotals : MonoBehaviour
{
    public TextMeshProUGUI secrets;
    public TextMeshProUGUI score;
    public TextMeshProUGUI congrats;
    public TextMeshProUGUI deaths; 
    int secretsCount;
    int deathCount;

    // Start is called before the first frame update
    void Start()
    {
        deathCount = PlayerHealth.DeathCount;
        secretsCount = PlayerMovement.secretCount;
        float x = 1200 - Time.time;
        if (x < 0)
        {
            x = 1;
        }
        float scoreTotal = (secretsCount * x)/deathCount;
        score.text = "Total Score: " + scoreTotal.ToString("0");
        secrets.text = "Secrets Collected: " + secretsCount.ToString();
        deaths.text = "Death Count: " + deathCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
