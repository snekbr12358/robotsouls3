using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Caixa caixa;
    public AlavancaController alavanca;

    Animator animator;
    private float velocidadeauto;
    private SpriteRenderer ImagemBoss;
    bool morreu = false;

    public int vida = 50;
    public float velocidade = 0.05f;
    public float distInicial = 0f;
    public float distFinal = 0f;
    // Start is called before the first frame update
    void Start()
    {
        ImagemBoss = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        velocidadeauto = velocidade;

    }

    // Update is called once per frame
    void Update()
    {
        if(!morreu) 
            Andar();
    }
    void Andar()
    {
        //mudar velocidade
        //Andar para trás
        if (transform.position.x > distFinal)
        {
            velocidade = velocidade * -1f;
            ImagemBoss.flipX = false;
        }
        //Andar para frente
        if (transform.position.x < distInicial)
        {
            velocidade = velocidade * -1f;
            ImagemBoss.flipX = true;
        }
        
        transform.position = new Vector3(transform.position.x + velocidade , transform.position.y, transform.position.z);
    }
    public void LevarDano(int dano)
    {
        if (!morreu) 
        { 
            vida -= dano;
            StartCoroutine("Vermelhinho");
            if (vida <= 0)
            {
                morreu = true;
                Destroy(gameObject, 1f);
                animator.SetBool("Morte", true);
                ImagemBoss.color = Color.white;
                alavanca.DesativarEscudo();
                
            }
        }
    }

    IEnumerator Vermelhinho()
    {
        ImagemBoss.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        ImagemBoss.color = Color.white;
    }

}
