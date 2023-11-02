using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;

    Vector2 moveInput;
    Rigidbody2D rb2d;

    public Transform feet;
    public Transform RightArm;
    public Transform LeftArm;
    public float DistanceFromFeet = 0.1f;
    //This boolean is equal to whether the player is touching the ground or not.
    public bool grounded;
    //This boolean is if the player is touching a wall
    public bool sided;
    public bool left;
    public bool right;

    public int MaxJumps = 3;
    public int Jumps;

    [SerializeField] int moveSpeed = 5;
    [SerializeField] int jumpSpeed = 5;
    [SerializeField] int wallJumpSpeed = 25;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Run();
        flipSprite();
        RaycastHit2D _hit = Physics2D.Raycast(feet.position, Vector2.down, DistanceFromFeet , 3);
        RaycastHit2D leftArm = Physics2D.Raycast(LeftArm.position, Vector2.left, DistanceFromFeet, 3);
        RaycastHit2D rightArm = Physics2D.Raycast(RightArm.position, Vector2.right, DistanceFromFeet, 3);
        grounded = _hit;
        sided = leftArm || rightArm;
        left = leftArm;
        right = rightArm;
        if (grounded)
        {
            Jumps = MaxJumps;
        }
        //animator.SetBool("Walking", rb2d.velocity.magnitude > 0);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (grounded)
        {
            rb2d.velocity += new Vector2(0f, jumpSpeed);
            return;
        }
        if (sided && Jumps > 0)
        {
            Jumps--;
            if (left)
            {
                rb2d.velocity = new Vector2(-wallJumpSpeed, jumpSpeed);
            }
            if (right)
            {
                rb2d.velocity = new Vector2(wallJumpSpeed, jumpSpeed);
            }
        }

    }

    void Run()
    {
        if (grounded || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, rb2d.velocity.y);
            rb2d.velocity = playerVelocity;
        }
    }

    void flipSprite()
    {
        switch (rb2d.velocity.x)
        {
            case > 0:
                GetComponent<SpriteRenderer>().flipX = true;
                break;
            case < 0:
                GetComponent<SpriteRenderer>().flipX = false;
                break;
        }
        //bool playerHaseHorizontalSpeed = Mathf.Abs(rb2d.velocity.x) > Mathf.Epsilon;
        /*
        if (playerHaseHorizontalSpeed)
        {
            //transform.localScale = new Vector2(-Mathf.Sign(rb2d.velocity.x), 1f);
        }*/
    }
}