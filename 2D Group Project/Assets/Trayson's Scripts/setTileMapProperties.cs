using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class setTileMapProperties : MonoBehaviour
{
    public float Friction;
    public float Bounciness;
    

    void Start()
    {
        PhysicsMaterial2D Material = new PhysicsMaterial2D { };
        Material.friction = Friction;
        Material.bounciness = Bounciness;
        GetComponent<TilemapCollider2D>().sharedMaterial = Material;
    }

}
