using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleBala : MonoBehaviour
{
    //VARIAVEIS 

    //VELOCIDADE DA BALA
    private float velocidade_bala = 0.1f;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoverBala();

    }

    //MOVIMENTAÇÃO DA BALA
    void MoverBala()
    {
        transform.position = new Vector3(transform.position.x + velocidade_bala, transform.position.y, transform.position.z);
    }

    //DIREÇÃO DA BALA
    public void DirecaoBala(float direcao)
    {
        velocidade_bala = direcao;
    }

    private void OnCollisionEnter2D(Collision2D colisao)
    {
        Debug.Log(colisao.gameObject.tag);
        if (colisao.gameObject.tag == "Inimigo")
        {
            //OUTRO OBJETO
            Destroy(colisao.gameObject);
            //ESTE OBJETO (BALA)
            Destroy(this.gameObject);
        }

    }
}