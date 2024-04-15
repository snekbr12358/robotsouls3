using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleBala : MonoBehaviour
{
    //VARIAVEIS 

    //VELOCIDADE DA BALA
    private int direcao;
    public float velocidade_bala;
    private bool pode_atira = true;

    public int dano;

    Rigidbody2D rb;

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.velocity = Vector2.right * velocidade_bala * direcao;
        Destroy(gameObject, 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        MoverBala();

    }

    private void FixedUpdate()
    {
        
    }

    //MOVIMENTAÇÃO DA BALA
    void MoverBala()
    {
        //transform.position = new Vector3(transform.position.x + velocidade_bala, transform.position.y, transform.position.z);
    }

    //DIREÇÃO DA BALA
    public void DirecaoBala(int dir)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        direcao = dir;
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
            VidaBoss VidaLamp = colisao.gameObject.GetComponent<VidaBoss>();
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
            else if (VidaLamp != null)
            {
                VidaLamp.LevarDano(dano);
            }
            //ESTE OBJETO (BALA)
            //Destroy(this.gameObject);
        }
        //if (colisao.gameObject.tag == "Caixa")
        //{
        //    Caixa caixa = colisao.gameObject.GetComponent<Caixa>();
        //    if (caixa != null)
        //    {
        //        caixa.LevarDano(dano);
        //    }
        //}
        
        if (colisao.gameObject.tag == "chao")
        {
            Debug.Log("chao");
            animator.SetTrigger("Destroy");
        }

        if (colisao.gameObject) 
        {
            animator.SetTrigger("Destroy");
        }

        rb.velocity = Vector3.zero;


    }

    public void destruir()
    {
        Destroy(this.gameObject);
    }

}