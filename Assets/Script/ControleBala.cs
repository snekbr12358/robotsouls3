using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleBala : MonoBehaviour
{
    //VARIAVEIS 

    //VELOCIDADE DA BALA
    private float velocidade_bala = 0.00000000000000005f;
    private bool pode_atira = true;

    public int dano;


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
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        velocidade_bala = direcao;
        if (direcao < 0)
            spriteRenderer.flipX = true;
    }

    private void OnCollisionEnter2D(Collision2D colisao)
    {
        Debug.Log(colisao.gameObject.tag);
        if (colisao.gameObject.tag == "Inimigo")
        {
 
            Slime slime = colisao.gameObject.GetComponent<Slime>();
            SlimeV slimev = colisao.gameObject.GetComponent<SlimeV>();
            Aranha aranha = colisao.gameObject.GetComponent<Aranha>();
            AranhaA aranhaa= colisao.gameObject.GetComponent<AranhaA>();
            Boss boss = colisao.gameObject.GetComponent<Boss>();
            if(slime != null)
            {
                slime.LevarDano(dano);
            }
            else if (slimev != null)
            {
                slimev.LevarDano(dano);
            }
            else if (aranha != null)
            {
                aranha.LevarDano(dano);
            }
            else if (aranhaa != null)
            {
                Debug.Log("dddd");
                aranhaa.LevarDano(dano);
            }
            else if (boss != null)
            {
                boss.LevarDano(dano);
            }
            //ESTE OBJETO (BALA)
            Destroy(this.gameObject);
        }
        if (colisao.gameObject.tag == "Caixa")
        {
            Caixa caixa = colisao.gameObject.GetComponent<Caixa>();
            if (caixa != null)
            {
                caixa.LevarDano(dano);
            }
        }
        Destroy(this.gameObject);
    }
    private void OnCollisionStay2D(Collision2D colisao)
    {
        if (colisao.gameObject.tag == "Caixa")
        {
            Caixa caixa = colisao.gameObject.GetComponent<Caixa>();
            if (caixa != null)
            {
               caixa.LevarDano(dano);
            }
        }
    }
}