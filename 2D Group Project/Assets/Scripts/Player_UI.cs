using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_UI : MonoBehaviour
{
    public GameObject Player;
    PlayerShoot playerShoot;
    public Slider LanternSlider;

    void Start()
    {
        playerShoot = Player.GetComponent<PlayerShoot>();
    }
    void Update()
    {
        LanternSlider.value = 2 - playerShoot.timer;
    }
}
