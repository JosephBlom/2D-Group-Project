using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    int scene;

    void OnTriggerEnter2D(Collider2D collision)
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene += 1);
    }
}
