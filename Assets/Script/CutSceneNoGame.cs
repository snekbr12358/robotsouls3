using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutScene : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public int nextScene;

    CutsceneController cutsceneController;
    // Start is called before the first frame update
    void Start()
    {
        if (videoPlayer.isPaused)
        {
            videoPlayer.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
                }
            }
        }
      
    }
    
}
