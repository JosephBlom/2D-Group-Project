using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainBoss : MonoBehaviour
{
    public Transform Player;
    public GameObject MeatBall;
    public Vector3 Offset;
    public bool Attack1;
    public float attackDelay;
    float nextTimeToFire;
    public float directionX;
    public float speed;
    public Slider slider;
    public TextMeshProUGUI slidertext;
    public string Name;
    public Animator animator;
    public int health;
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        slidertext.text = name;
        slider.maxValue = health;
        animator.Play("BlackBars");
        Player.GetComponent<PlayerShoot>().timer = 0.5f;
    }

    void Attack()
    {
        Instantiate(MeatBall, transform.position + Offset, Quaternion.identity);
    }

    void Update()
    {
        slider.value = health;
        if (Attack1)
        {
            Attack1 = false;
            Attack();
        }
        if (Time.time > nextTimeToFire)
        {
            nextTimeToFire = Time.time + attackDelay;
            Attack();
        }
        directionX = Player.position.x - transform.position.x;

        transform.position += new Vector3(directionX * Time.deltaTime * speed, 0, 0);
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.Play("BlackBarsBack");
        Destroy(gameObject);
    }
}
