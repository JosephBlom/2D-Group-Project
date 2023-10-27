using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class LeviathanScript : MonoBehaviour
{
    public GameObject Player;
    public bool AttackingTime = false;
    public int Segments = 10;
    public GameObject SegmentObject;
    public Transform BodyParent;
    public Rigidbody2D Head;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (AttackingTime)
        {
            AttackingTime = false;
            Attack();
        }
        Vector3 direction = Player.transform.position - Head.transform.position;
        int directInt = Mathf.RoundToInt(direction.normalized.x);
        Head.velocity = direction;
        if (directInt == 0)
        {
            directInt = 1;
        }
        Head.transform.localScale = new Vector3(1, directInt, 1);
        float angle = Mathf.Atan2(direction.normalized.y, direction.normalized.x) * Mathf.Rad2Deg;
        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(0, 0, angle);
        Head.transform.rotation = rotation;
    }

    void Attack()
    {
        Debug.Log("Attack");
        StartCoroutine(GenerateLeviathan());
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
            yield return new WaitForSecondsRealtime(10/Segments);
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
                //temp.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
        }
    }
}
