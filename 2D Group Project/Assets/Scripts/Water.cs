using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().gravityScale = 2;
            collision.GetComponent<Rigidbody2D>().drag = 5;
            collision.GetComponent<PlayerMovement>().Swimming = true;
            collision.GetComponent<PlayerMovement>().jumpSpeed = 10;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().gravityScale = 3;
            collision.GetComponent<Rigidbody2D>().drag = 0;
            collision.GetComponent<PlayerMovement>().Swimming = false;
            collision.GetComponent<PlayerMovement>().jumpSpeed = 15;
        }
    }
}
