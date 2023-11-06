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
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        GenerateLeviathan();
    }

    float nextTimeToFire = 0;
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
        else if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            directionY = Player.transform.position.y - Head.transform.position.y;

            Body.transform.position += new Vector3(0, directionY * Time.deltaTime * speed, 0);

            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + AttackEverySeconds;
                animator.Play("Attack");
            }
        }

    }

    //Todo: Make attack an actual thing. NVM.
    public IEnumerator Attack()
    {
        foreach (Transform t in AttackingSpots)
        {
            yield return new WaitForSeconds(AttackEverySeconds);
            animator.Play("Attack");
        }

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
}
