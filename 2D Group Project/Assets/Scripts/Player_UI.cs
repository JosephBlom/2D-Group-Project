using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI totalTimeText;
    bool time = false;
    bool bossHere;
    void Start()
    {
        playerShoot = Player.GetComponent<PlayerShoot>();
        bossHere = GameObject.FindGameObjectsWithTag("Boss").Length > 0;
        BossHealthSlider.value = 1;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            time = !time;
        }
        timeText.gameObject.SetActive(time);
        totalTimeText.gameObject.SetActive(time);
        timeText.text = "Time This Level: " + Time.timeSinceLevelLoad.ToString("0.00");
        totalTimeText.text = "Total Time: " + Time.time.ToString("0.00");
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