using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetarItem : MonoBehaviour
{
    public int vidaMaxima = 3;
    private int vidaAtual;


    // Start is called before the first frame update
    void Start()
    {
        vidaAtual = vidaMaxima;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void PegarItem()
    {
        if (vidaAtual < vidaMaxima)
        {
            vidaAtual++;
        }
        else
        {

        }
    }
}

