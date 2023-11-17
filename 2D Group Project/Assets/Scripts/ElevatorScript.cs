using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public Transform[] Levels;
    public Transform ActiveLevel;
    public Rigidbody2D rb;
    public bool CanGoUp;
    public float speed;
    public int Level = 0;

    void Start()
    {
        ActiveLevel = transform;
        rb.drag = 10;
        rb.mass = 100;
        rb.gravityScale = 0;
        rb.freezeRotation = true;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !CanGoUp)
        {
            ActiveLevel = Levels[Level];

            Vector3 Direction = Vector3.up * (ActiveLevel.position.y - transform.position.y);
            if (Vector3.Distance(Vector3.up * ActiveLevel.transform.position.y, Vector3.up * transform.position.y) < 0.1f)
            {
                transform.position = new Vector3(transform.position.x, ActiveLevel.transform.position.y, transform.position.z);
            }
            else
            {
                rb.velocity = Direction.normalized * speed;

            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && Level < Levels.Length - 1 && CanGoUp)
        {
            Level++;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && Level > 0)
        {
            Level--;
        }

        if (CanGoUp)
        {
            ActiveLevel = Levels[Level];

            Vector3 Direction = Vector3.up * (ActiveLevel.position.y - transform.position.y);
            if (Vector3.Distance(Vector3.up * ActiveLevel.transform.position.y, Vector3.up * transform.position.y) < 0.1f)
            {
                transform.position = new Vector3(transform.position.x, ActiveLevel.transform.position.y, transform.position.z);
            }
            else
            {
                rb.velocity = Direction.normalized * speed;

            }
        }
    }
}
