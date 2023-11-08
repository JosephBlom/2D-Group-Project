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

    public bool Swimming;

    public Transform feet;
    public Transform RightArm;
    public Transform LeftArm;
    public float DistanceFromFeet = 0.1f;
    //This boolean is equal to whether the player is touching the ground or not.
    public bool grounded;
    //This boolean is if the player is touching a wall
    public bool sided;
    //This boolean is if the player is touching a left wall
    public bool left;
    //You can probably guess.
    public bool right;

    public int MaxJumps = 3;
    public int Jumps;

    public int moveSpeed = 5;
    public int jumpSpeed = 5;
    public int wallJumpSpeed = 25;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        //animator.SetBool("Running", Mathf.Abs(rb2d.velocity.x) > Mathf.Epsilon);
        animator.SetFloat("x", Mathf.Abs(rb2d.velocity.x)); 
        //Applying Movement.
        if (grounded || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, rb2d.velocity.y);
            rb2d.velocity = playerVelocity;
        }

        //Flipping Sprite Based On Velocity.
        switch (rb2d.velocity.x)
        {
            case > 0:
                GetComponent<SpriteRenderer>().flipX = true;
                break;
            case < 0:
                GetComponent<SpriteRenderer>().flipX = false;
                break;
        }

        //Calculating Raycast Booleans.
        RaycastHit2D _hit = Physics2D.Raycast(feet.position, Vector2.down, DistanceFromFeet, 3);
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
        if (leftArm)
        {
            if (leftArm.collider.transform.CompareTag("ToggleDoor") && Input.GetKeyDown(KeyCode.E))
            {
                leftArm.collider.transform.gameObject.SetActive(false);
            }
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (grounded || Swimming)
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
}