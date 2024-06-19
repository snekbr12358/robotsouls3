using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BrainBoss : MonoBehaviour
{
    public AlavancaController alavanca;
    public AtivarBarreira Barreira;

    Animator animator;
    
    private SpriteRenderer ImagemBoss;
    bool morreu = false;

    public int vida = 50;
    
    public VidaBoss2 Vida1;
    public VidaBoss2 Vida2;

    public GameObject Mira;
    public GameObject Brilho;

    public VideoPlayer videoPlayer;

    public GameObject EncontroBoss;

    // Start is called before the first frame update
    void Start()
    {
        ImagemBoss = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        //videoPlayer = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.isPaused)
        {
            videoPlayer.Stop();
            Time.timeScale = 1f;
        }
        if (!morreu)
        {      
          VerificarVida();
        }
    }
    

    void VerificarVida()
    {
        if (Vida1.vida <= 0 && Vida2.vida <= 0)
        {

            morreu = true;
            if (Mira != null)
            {
                Destroy(Mira);
            }           
            if (Brilho != null)
            {
                Destroy(Brilho, 1f);
            }
            if (!videoPlayer.isPlaying)
            {
                videoPlayer.Play();
                Time.timeScale = 0f;
            }           
            alavanca.DesativarEscudo();
            ImagemBoss.color = Color.white;
            EncontroBoss.SetActive(false);


        }
    }
   
   


    //IEnumerator Vermelhinho()
    //{
    //    ImagemBoss.color = Color.red;
    //    yield return new WaitForSeconds(0.5f);
    //    ImagemBoss.color = Color.white;
    //}

}
