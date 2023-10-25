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
    public JosephTest BossStats;

    float BossHealth;

    void Start()
    {
        playerShoot = Player.GetComponent<PlayerShoot>();
        BossHealthSlider.value = 2;
    }
    void Update()
    {
        LanternSlider.value = 2 - playerShoot.timer;
        BossHurt();
        
    }

    void BossHurt()
    {
        BossHealth = BossStats.bossHealth;
        BossHealthSlider.value = (BossHealth / 100);
        BossHealthSlider.gameObject.SetActive(BossHealthSlider.value > 0);
    }
}
