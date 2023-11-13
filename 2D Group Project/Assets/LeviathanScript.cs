using System.Collections;
using UnityEngine;

public class LeviathanScript : MonoBehaviour
{
    public GameObject Player;
    public bool MovesWithoutAnim;
    public int Segments = 10;
    public float speed;
    public Transform BodyParent;
    public Transform Body;
    public GameObject SegmentObject;
    public Rigidbody2D Head;
    public float AttackEverySeconds = 10f;
    public Transform[] AttackingSpots;
    public Animator animator;
    public float directionY;
    float nextTimeToFire = 10f;
    public Animator canvasAnim;
    public GameObject Boss;
    public LeviathanHealth health;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        GenerateLeviathan();
    }

    private void Update()
    {
        if (MovesWithoutAnim)
        {
            //Calculate Vars
            Vector3 direction = Player.transform.position - Head.transform.position;
            float angle = Mathf.Atan2(direction.normalized.y, direction.normalized.x) * Mathf.Rad2Deg;

            //Check if directint == 0, if so then make it equal to 1.
            int directInt = Mathf.RoundToInt(direction.normalized.x);
            if (directInt == 0) { directInt = 1; }

            //Apply Vars
            Head.velocity = direction.normalized * speed;
            Head.transform.localScale = new Vector3(1, directInt, 1);
            Head.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !animator.GetCurrentAnimatorStateInfo(0).IsName("EnterScene") && !animator.GetCurrentAnimatorStateInfo(0).IsName("ShakeBody") && !animator.GetCurrentAnimatorStateInfo(0).IsName("DeadLev"))
        {
            directionY = Player.transform.position.y - Head.transform.position.y;

            Body.transform.position += new Vector3(0, directionY * Time.deltaTime * speed, 0);

            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + AttackEverySeconds;
                animator.Play("Attack");
            }
        }
        if (health.health <= 0)
        {
            animator.enabled = false;
            canvasAnim.Play("BlackBarsBack");
            Invoke("OnDeath", 5);
        }

    }

    void OnDeath()
    {
        Boss.SetActive(true);
        gameObject.SetActive(false);
    }

    public void GenerateLeviathan()
    {
        Head.bodyType = RigidbodyType2D.Dynamic;
        Rigidbody2D LastBody = null;
        foreach (Transform t in BodyParent)
        {
            Destroy(t.gameObject);
        }
        for (int i = 0; i < Segments; i++)
        {
            GameObject temp = Instantiate(SegmentObject, new Vector2(Head.transform.position.x - i, Head.transform.position.y - 0.75f), Quaternion.identity);
            temp.transform.parent = BodyParent;
            if (LastBody == null)
            {
                temp.GetComponent<HingeJoint2D>().connectedBody = Head;
            }
            else
            {
                temp.GetComponent<HingeJoint2D>().connectedBody = LastBody;
            }
            LastBody = temp.GetComponent<Rigidbody2D>();
            if (i == Segments - 1)
            {
                temp.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
        }
    }

    public void DegenerateLeviathan()
    {
        foreach (Transform t in Head.transform)
        {
            t.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            t.GetComponent<Rigidbody2D>().gravityScale = 0.6f;
        }
        foreach (Transform t in BodyParent)
        {
            animator.Play("ShakeBody");
            t.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            t.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
