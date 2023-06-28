using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Portao : MonoBehaviour
{
    public AlavancaController Alavanca;
    public float velocidade = 2f;
   
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Alavanca.Ativada == true)
        {
            transform.Translate(Vector2.up * Time.deltaTime * velocidade);
        }
    }
    
}
