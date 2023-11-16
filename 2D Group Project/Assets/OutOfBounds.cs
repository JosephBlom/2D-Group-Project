using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int Scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(Scene);
    }
}
