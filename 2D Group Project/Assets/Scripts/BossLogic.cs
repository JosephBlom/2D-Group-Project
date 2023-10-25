using UnityEngine;
using System.Collections;
using System;
using UnityEditor.Rendering;
using JetBrains.Annotations;

public class BossLogic : MonoBehaviour
{

    public GameObject player;
    public GameObject aoeZone;
    public GameObject aoeAttack;
    public int bossHealth = 100;

    bool alive = true;
    float timer = 0f;

    void Start()
    {

    }
    
    void Update()
    {
        checkDie();
        if (alive)
        {
            timer += Time.deltaTime;
            if (timer > 3f)
            {
                StartCoroutine(bossAOE());
            }
        }
        
    }

    IEnumerator bossAOE()
    {
        Vector3 playerPos = player.transform.position;
        GameObject aoeWarning = Instantiate(aoeZone, playerPos, Quaternion.identity);
        timer = 0f;
        yield return new WaitForSeconds(2);
        Destroy(aoeWarning);
        GameObject aoeHitbox = Instantiate(aoeAttack, playerPos, Quaternion.identity);
        yield return new WaitForSeconds(0.15f);
        Destroy(aoeHitbox);
    }

    void checkDie()
    {
        if(bossHealth > 0)
        {
            alive = true;
        }
        else
        {
            alive = false;
            Destroy(gameObject,2.5f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lantern"))
        {
            bossHealth -= 10;
        }
    }
}

