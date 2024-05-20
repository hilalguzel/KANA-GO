using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    private Scene _scene;
    private void Awake()
    {
        _scene=SceneManager.GetActiveScene();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            totalscore.total_timer = 20;
            totalscore.total_hourglass_score = 0;
            SceneManager.LoadScene(1);
        }
    }
}
