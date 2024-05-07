using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    int level;
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        level = scene.buildIndex;
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            Persogem player = collision.GetComponent<Persogem>();
            player.SaveGameState(level);
        }
    }

}
