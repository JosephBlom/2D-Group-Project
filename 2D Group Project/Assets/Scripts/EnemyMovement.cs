using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]

public class EnemyMovement : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    public float RayDistance;
    public float chaseSpeed = 2.0f;
    public float chaseTriggerDistance = 3.0f;
    public Vector3 startPosition;
    public bool home = true;
    public Vector2 paceDirection = new Vector2(0f, 0f);
    public float paceDistance = 3.0f;
    public float jumpSpeed;
    public bool jumping = false;
    CapsuleCollider2D capsuleCollider;
    float gravity;
    // Use this for initialization
    void Start()
    {
        //get the spawn position so we know how to get home
        gravity = GetComponent<Rigidbody2D>().gravityScale;
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float verticalVelocity = GetComponent<Rigidbody2D>().velocity.y;
        verticalVelocity = gravity;
        Vector2 playerPosition = player.transform.position;
        Vector2 chaseDirection = new Vector2(playerPosition.x - transform.position.x, 0);
        if (chaseDirection.magnitude < chaseTriggerDistance && !jumping)
        {
            //player gets too close to the enemy
            home = false;

            chaseDirection.y = 0f;
            chaseDirection.Normalize();
            RaycastHit2D _hit = Physics2D.Raycast(transform.position, Vector2.down, RayDistance, 3);
            if (_hit)
            {
                animator.SetBool("Walking", true);
                GetComponent<Rigidbody2D>().velocity = chaseDirection * chaseSpeed;
            }
           
        }
        else if (home == false && !jumping)
        {
            Vector2 homeDirection = new Vector2(startPosition.x - transform.position.x, startPosition.y - transform.position.y);
            //Vector2 homeDirection = new Vector2(transform.position.x - startPosition.x, transform.position.y - startPosition.y);
            if (homeDirection.magnitude < 0.3f)
            {
                //we've arrived home
                home = true;
                animator.SetBool("Walking", false);
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
            else
            {
                //go home
                animator.SetBool("Walking", true);
                GetComponent<Rigidbody2D>().velocity = homeDirection.normalized * chaseSpeed;
            }
        }
        else if(!jumping)
        {
            Vector3 displacement = transform.position - startPosition;
            float distanceFromStart = displacement.magnitude;
            if (distanceFromStart >= paceDistance)
            {
                //do stuff, we've gone too far
                paceDirection = -displacement;
            }
            paceDirection.Normalize();
            GetComponent<Rigidbody2D>().velocity = paceDirection * chaseSpeed;
        }
        switch (GetComponent<Rigidbody2D>().velocity.x)
        {
            case > 0:
                GetComponent<SpriteRenderer>().flipX = true;
                break;
            case < 0:
                GetComponent<SpriteRenderer>().flipX = false;
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            jumping = true;
            GetComponent<Rigidbody2D>().velocity += new Vector2(0f, jumpSpeed);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            jumping = false;
        }
    }
}
