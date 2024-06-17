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
        if (Input.anyKeyDown)
        {
           
        }
        if (videoPlayer.isPaused)
        {
            videoPlayer.Stop();
            

        if(Mira != null)
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
                    videoPlayer.Play();
                    Mira.SetActive(false);
                    Time.timeScale = 0;
                }
            }
        }
      
     }
    
}
