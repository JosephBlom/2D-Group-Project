using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainBoss : MonoBehaviour
{
    public GameObject[] bossMoves;
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
    public int meatBallSpeed;
    int i;
    int chosenMove;
    Vector3 shootDirection;
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        slidertext.text = name;
        slider.maxValue = health;
        animator.Play("BlackBars");
        Player.GetComponent<PlayerShoot>().timer = 0.5f;
        i = bossMoves.Length;
        
    }

    void Attack()
    {
        shootDirection = Player.position - transform.position;
        shootDirection.Normalize();
        GameObject meatBall = Instantiate(MeatBall, transform.position + Offset, Quaternion.identity);
        meatBall.GetComponent<Rigidbody2D>().velocity = shootDirection * meatBallSpeed;
        StartCoroutine(move());
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
        
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.Play("BlackBarsBack");
        Destroy(gameObject);
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene + 1);
    }

    IEnumerator move()
    {
        yield return new WaitForSeconds(10000);
        chosenMove = Random.Range(1, i - 1);
        transform.position = bossMoves[chosenMove].transform.position;
    }
}
