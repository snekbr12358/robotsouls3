using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerraC : MonoBehaviour
{
    public float velocidade = 0.03f;
    public float distInicial = 0f;
    public float distFinal = 0f;
    private float velocidadeauto;

    void Start()
    {

        
    }

    void Update()
    {
       
    }
    void Andar()
    {
        transform.position = new Vector3(transform.position.x + velocidadeauto * Time.deltaTime, transform.position.y, transform.position.z);
        //mudar velocidade
        //Andar para trás
        if (transform.position.x > distFinal)
        {
            velocidadeauto = velocidade * -1f;   
        }
        //Andar para frente
        if (transform.position.x < distInicial)
        {
            velocidadeauto = velocidade * 1f;
        }
    }
}
