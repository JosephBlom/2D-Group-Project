using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainBoss : MonoBehaviour
{
    PlayerHealth playerHealth
    public GameObject[] bossMoves;
    public Transform Player;
    public GameObject MeatBall;
    public Vector3 Offset;
    public bool Attack1;
    public float attackDelay;
    float nextTimeToFire = 3;
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
    float timer;
    void Start() 
    {
        playerHealth = GetComponent<PlayerHealth>();
        Player = GameObject.FindWithTag("Player").transform;
        slidertext.text = name;
        slider.maxValue = health;
        animator.Play("BlackBars");
        Player.GetComponent<PlayerShoot>().timer = 0.5f;
        Player.GetComponent<PlayerShoot>().bulletSpeed = 15f;
        i = bossMoves.Length;
        
    }


    void Update()
    {
        slider.value = health;
        if (Attack1)
        {
            Attack1 = false;
            StartCoroutine(Attack());
        }
        if (timer >= nextTimeToFire)
        {
            timer = 0;
            StartCoroutine(Attack());
        }
        
        if (health <= 0)
        {
            Die();
        }
        timer += Time.deltaTime;
    }

    void Die()
    {
        animator.Play("BlackBarsBack");
        Destroy(gameObject);
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene + 1);
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(nextTimeToFire);
        shootDirection = Player.position - transform.position;
        shootDirection.Normalize();
        GameObject meatBall = Instantiate(MeatBall, transform.position, Quaternion.identity);
        meatBall.GetComponent<Rigidbody2D>().velocity = shootDirection * meatBallSpeed;
        yield return new WaitForSeconds(0.3f);
        chosenMove = Random.Range(1, i - 1);
        transform.position = bossMoves[chosenMove].transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lantern"))
        {
            health -= 30;
        }
        else if (collision.CompareTag("Player"))
        {
            playerHealth.Health = 0;
        }
    }

}
