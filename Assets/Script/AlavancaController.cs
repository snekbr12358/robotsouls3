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

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
                        videoPlayer.Play();
                    }
                }
            }
        }
    }
}

    


