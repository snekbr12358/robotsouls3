 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class AlavancaController : MonoBehaviour
{
    public Gate gateController;

    public VideoPlayer videoPlayer;
    public int nextScene;

    Animator animator;

    public GameObject aboboda;

    public bool Ativada;
    public bool LampLig;

    public GameObject lampada;
    private Animator lampadaAnimator;

    CutsceneController cutsceneController;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        if (lampada != null)
        {
            lampadaAnimator = lampada.GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.isPaused)
        {
            videoPlayer.Stop();
        }
    }
    public void DesativarEscudo() 
    { 
        aboboda.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (gateController != null)
        {
            if(collision.tag == "Player")
            {
                if (!aboboda.activeSelf)
                {                   
                    animator.SetBool("Ativada", true);
                    Ativada = true;
                    animator.SetBool("LampLig", true);
                    LampLig = true;
                    if (gateController.isActiveAndEnabled)
                    {                      
                        gateController.HideGate();
                    }
                    else
                    {
                        gateController.ShowGate();
                    }
                    if (videoPlayer != null)
                    {
                        if (!videoPlayer.isPlaying) 
                        { 
                            videoPlayer.Play();
                        }
                    }
                    if (lampadaAnimator != null)
                    {
                        lampadaAnimator.SetBool("LampLig", true);
                    }
                }
            }
        }
    }
}

    


