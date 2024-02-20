using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caixa : MonoBehaviour
{
    private Renderer gateRenderer;
    private bool gateVisible = true;




    public AudioSource audioSource;
    
    Animator animator;

    private SpriteRenderer ImagemCaixa;

    public AlavancaController alavanca;

    bool morreu = false;

    public int vida = 6;

    // Start is called before the first frame update
    void Start()
    {
        gateRenderer = GetComponent<Renderer>();


        ImagemCaixa = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!morreu)
        {

        }
    }
    public void LevarDano(int dano)
    {
        if (!morreu && alavanca.Ativada)
        {
            vida -= dano;
            if (vida <= 0)
            {
                audioSource.Play();
                morreu = true;
                Destroy(gameObject, 0.7f);
                animator.SetBool("Morte", true);
                ImagemCaixa.color = Color.white;
            }
        }
    }
    public void ShowGate()
    {
        gateVisible = true;
        gateRenderer.enabled = true;
    }


    public void HideGate()
    {
        gateVisible = false;
        gateRenderer.enabled = false;
    }
}

