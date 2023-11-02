using System.Collections;
using UnityEngine;

public class LeviathanScript : MonoBehaviour
{
    public GameObject Player;
    public int Segments = 10;
    public float speed;
    public Transform BodyParent;
    public GameObject SegmentObject;
    public Rigidbody2D Head;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(GenerateLeviathan());
    }

    private void Update()
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

    //Todo: Make attack an actual thing.
    public void Attack()
    {
        
    }

    IEnumerator GenerateLeviathan()
    {
        Head.bodyType = RigidbodyType2D.Dynamic;
        Rigidbody2D LastBody = null;
        foreach (Transform t in BodyParent)
        {
            Destroy(t.gameObject);
        }
        for (int i = 0; i < Segments; i++)
        {
            //This is so that it doesn't just generate instantly so the player can see 
            yield return new WaitForSeconds(0.05f);
            GameObject temp = Instantiate(SegmentObject, new Vector2(Head.transform.position.x - i, Head.transform.position.y), Quaternion.identity);
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
