using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serra : MonoBehaviour
{
    public float velocidade = 2.0f;
    private Vector2 direcao;

    void Start()
    {

        direcao = transform.up;
    }

    void Update()
    {
        transform.Translate(direcao * velocidade * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("chao"))
        {
            direcao = -direcao;
        }


    }
}
