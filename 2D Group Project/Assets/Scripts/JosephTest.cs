using UnityEngine;
using System.Collections;
using System;
using UnityEditor.Rendering;

public class JosephTest : MonoBehaviour
{

    public GameObject player;
    public GameObject aoeZone;
    public GameObject aoeAttack;


    float timer = 0f;


    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3f)
        {
            bossAOE();
            
        }
    }

    IEnumerator bossAOE()
    {
        Vector3 playerPos = player.transform.position;
        GameObject aoeWarning = Instantiate(aoeZone, playerPos, Quaternion.identity);
        yield return new WaitForSeconds(2);
        Destroy(aoeWarning);
        GameObject aoeHitbox = Instantiate(aoeAttack, playerPos, Quaternion.identity);
        timer = 0f;
    }
}

