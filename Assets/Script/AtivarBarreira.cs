using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarBarreira : MonoBehaviour
{
    public Collider2D barreira; 
    public float tempoParaAtivar = 3f; 

    private bool barreiraAtivada = false;
    private bool desativarAposMorte = false;
    private float tempoDecorrido = 0f;

    public Animator animator;


    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("fechar", true);
        }
    }

    void Update()
    {

    }

    public void AbrirPortao() 
    {
        animator.SetBool("fechar", false);
    }

    public void FecharPortao() 
    {
        animator.SetBool("fechar", true);
    }


    public void DesativarAposMorte()
    {
        AbrirPortao();
        barreira.gameObject.SetActive(false);
    }

}