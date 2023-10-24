using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lantern"))
        {
            OnTorchTouched();
        }
    }
    public virtual void OnTorchTouched()
    {
        
    }
}
