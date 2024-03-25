using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntervaloCena : MonoBehaviour
{
    public GameObject menu;
    public VideoPlayer videoPlayer;
    public float contador;
    

    void Start()
    {
        videoPlayer.loopPointReached += EndReached;
    }

    private void Update()
    {
        if (contador >= 10 && !videoPlayer.gameObject.activeSelf) 
        { 
            menu.SetActive(false);
            videoPlayer.gameObject.SetActive(true);
        }
        contador += Time.deltaTime;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        menu.SetActive(true);
        videoPlayer.gameObject.SetActive(false);
        contador = 0;
    }
}