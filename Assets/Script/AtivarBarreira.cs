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

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            
            barreiraAtivada = true;
        }
    }

    void Update()
    {
    
        if (barreiraAtivada && tempoDecorrido >= tempoParaAtivar)
        {
            
            barreira.isTrigger = true;
        }
        else
        {
          
            tempoDecorrido += Time.deltaTime;
        }
    }

    public void DesativarAposMorte()
    {
        if (desativarAposMorte)
        {
            barreira.isTrigger =false;
        }
    }

    public void SetDesativarAposMorte(bool desativar)
    {
        desativarAposMorte = desativar;
    }

}