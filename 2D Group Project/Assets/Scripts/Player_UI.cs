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
    void Start()
    {
        playerShoot = Player.GetComponent<PlayerShoot>();
        bossHere = GameObject.FindGameObjectsWithTag("Boss").Length > 0;
        BossHealthSlider.value = 1;
    }
    void Update()
    {
        LanternSlider.value = -(Time.time - playerShoot.fireTime);
        LanternSlider.maxValue = playerShoot.timer;
        BossHurt();
    }

    void BossHurt()
    {
        BossHealthSlider.gameObject.SetActive(bossHere);
        if (!bossHere)
            return;
        BossHealthSlider.value = (Boss.GetComponent<BossLogic>().bossHealth / 100);
        BossHealthSlider.gameObject.SetActive(BossHealthSlider.value > 0);
    }
}