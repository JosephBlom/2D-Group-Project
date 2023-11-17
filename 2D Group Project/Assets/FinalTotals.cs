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
    PlayerMovement playerMovement;
    int secretsCount;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement.GetComponent<PlayerMovement>();
        secretsCount = PlayerMovement.secretCount;
        float x = 1200 - Time.time;
        if (x < 0)
        {
            x = 1;
        }
        float scoreTotal = secretsCount * x;
        score.text = scoreTotal.ToString("0");
        secrets.text = secretsCount.ToString();
        if(scoreTotal <= secretsCount)
        {
            congrats.text = "How Did This Take You Over 20 Minutes?";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
