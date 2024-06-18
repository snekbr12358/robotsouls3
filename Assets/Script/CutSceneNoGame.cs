using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutScene : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    CutsceneController cutsceneController;

    public GameObject Mira;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.isPlaying) { 
            if (Input.anyKeyDown)
            {
                videoPlayer.Stop();
                Time.timeScale = 1;
            }
        }
        
        if (videoPlayer.isPaused)
        {
            videoPlayer.Stop();
            Time.timeScale = 1;

            if (Mira != null)
        {
           Mira.SetActive(true);
        }
           Destroy(gameObject);
        }
    }
     private void OnTriggerEnter2D(Collider2D collision)
     {
        if (collision.tag == "Player")
        {
            if (videoPlayer != null)
            {
                if (!videoPlayer.isPlaying)
                {
                    Time.timeScale = 0;
                    videoPlayer.Play();
                    Mira.SetActive(false);                   
                }
            }
        }
      
     }
    
}
