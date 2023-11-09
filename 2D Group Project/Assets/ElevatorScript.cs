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
    public float speed;
    public int Level = 0;

    private void Start()
    {
        ActiveLevel = transform;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && Level < Levels.Length - 1)
        {
            Level++;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && Level > 0)
        {
            Level--;
        }
    }
}
