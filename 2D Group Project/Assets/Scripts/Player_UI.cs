using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_UI : MonoBehaviour
{
    public GameObject Player;
    public GameObject Boss;
    PlayerShoot playerShoot;
    public Slider LanternSlider;
    public Slider BossHealthSlider;
    public BossLogic BossStats;
    bool bossHere;
    GameObject[] temp;

    float BossHealth;

    void Start()
    {
        temp = GameObject.FindGameObjectsWithTag("Boss");
        if(temp.Length>0 )
        {
            bossHere = true;
        }
        playerShoot = Player.GetComponent<PlayerShoot>();
        BossHealthSlider.value = 2;
    }
    void Update()
    {
        LanternSlider.value = 2 - playerShoot.timer;
        if (bossHere)
        {
            BossHurt();
        }
        
        
    }

    void BossHurt()
    {
        BossHealth = BossStats.bossHealth;
        BossHealthSlider.value = (BossHealth / 100);
        BossHealthSlider.gameObject.SetActive(BossHealthSlider.value > 0);
    }
}
