using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class JosephTest : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rb2d;

    [SerializeField] int moveSpeed = 5;
    [SerializeField] int jumpSpeed = 5;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Run();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        rb2d.velocity += new Vector2(0f, jumpSpeed);
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, rb2d.velocity.y);
        rb2d.velocity = playerVelocity;
    }
}