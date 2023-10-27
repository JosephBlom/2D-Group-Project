using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LeviathanScript : MonoBehaviour
{
    public GameObject Player;
    public bool AttackingTime = false;
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
    }

    void Attack()
    {
        Debug.Log("Attack");
    }
}
