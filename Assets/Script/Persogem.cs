using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Drawing;
using Unity.VisualScripting;

public class Persogem : MonoBehaviour
{
    public Rigidbody2D Corpo;
    public float velocidade;
    public int qtd_pulo = 0;
    private float meuTempoPulo = 0;
    public LayerMask groundLayer;

    public float velocidadeBala;

    //Componete SpriteRenderer
    public SpriteRenderer ImagemPersonagem;
    //Componet Bala
    public GameObject Bala;
    private float meuTempoTiro;
    private bool pode_atira;

    //Conponet Icon
    public GameObject idle_icon;

    //vida do personagem
    public int vida = 50;
    int vidamax;
    private float meuTempoDano = 0;
    public bool pode_pular = true;

    public Animator animator;

    //barra de hp
    private bool pode_dano = true;
    public Image[] barrahp;

    //Moeda
    public int moedas = 0;
    private Text Moeda_texto;

    public GerenciadorJogo GJ;
 
    



    // Start is called before the first frame update
    void Start()
    {
        //Moeda_texto = GameObject.FindGameObjectWithTag("Moeda_texto_tag").GetComponent<Text>();
        //barrahp = GameObject.FindGameObjectWithTag("hp_barra").GetComponent<Image>();
        animator = GetComponent<Animator>();
        GJ = FindObjectOfType<GerenciadorJogo>();
        vidamax = vida;
    }

    // Update is called once per frame
    void Update()
    {
        if (GJ.EstadoDoJogo()) 
        { 
            Mover();
            Apontar();
            Pular();
            Atirar();
            Dano();
        }
    }
    void Mover()
    {
        velocidade = Input.GetAxis("Horizontal") * 8;
        Corpo.velocity = new Vector2(velocidade, Corpo.velocity.y);
        if (Mathf.Abs(velocidade)> 0)
        {
            idle_icon.SetActive(false);

            animator.SetBool("Andar", true);
        }
        else
        {
            idle_icon.SetActive(true);

            animator.SetBool("Andar", false);
        } 
    }
    void Apontar()
    {
        if(velocidade > 0)
        {
           
            ImagemPersonagem.flipX = false;
        }
        if(velocidade < 0)
        {
           
            ImagemPersonagem.flipX = true;
        }
    }
    void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Space) && pode_pular == true)
        {
            idle_icon.SetActive(false); 
            animator.SetBool("Pula", true);
            pode_pular = false;
            qtd_pulo++;
            if (qtd_pulo <= 2)
                AcaoPulo();
        }
        if(pode_pular == false)
        {
            TemporizadorPulo();
        }
    }
    void AcaoPulo()
    {
        //Corpo.velocity = new Vector2(velocidade, 0);
        Corpo.AddForce(Vector2.up * 400f);
    }
    //Gatilhos
    void OnTriggerEnter2D(Collider2D gatilho)
    {
        if (gatilho.gameObject.tag == "chao")
        {
            idle_icon.SetActive(false);
            animator.SetBool("Pula", false);
            qtd_pulo = 0;
            pode_pular = true;
            meuTempoPulo = 0; 

        }
        if(gatilho.gameObject.tag == "Moeda")
        {
           Destroy(gatilho.gameObject);
            moedas++;
            Moeda_texto.text = moedas.ToString();
        }
    }
    
    //Tempo de Pulo
    void TemporizadorPulo()
    {
        meuTempoPulo += Time.deltaTime;
        if (meuTempoPulo > 0.5)
        {
            pode_pular =true;
            meuTempoPulo = 0;
        }
    }


    // Gatilhos
    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.tag == "Inimigo")
        {
            if (pode_dano == true)
            {
                vida--;
                Perderhp();
                pode_dano = false;
                //ImagemPersonagem.color = UnityEngine.Color.red;
                meuTempoDano = 0;
                animator.SetTrigger("Dano");
                //só morro se minha vida for menor ou igual a 0
                if (vida <= 0)
                {
                    Morrer();
                }
            }
        }
        if(colisao.gameObject.tag == "morte_imediata")
        {
            if(pode_dano == true)
            {
                pode_dano = false;
                vida = vida - 3;
                Perderhp();
                SceneManager.LoadScene(5);
            }
        }
    }
    //Atira Balas
    void Atirar()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {           
            animator.SetTrigger("Ataque");
           //Instantiate(Bala, this.transform.position, this.transform.rotation);
            Disparor();
        }
    }

    void Disparor()
    {
        Vector3 pontoDisparo = Vector3.zero;
        if (ImagemPersonagem.flipX)
        {
            pontoDisparo = new Vector3(
                transform.position.x - 1f,
                transform.position.y ,
                transform.position.z);
            GameObject BalaDisparada = Instantiate(Bala, pontoDisparo, Quaternion.identity);
            BalaDisparada.GetComponent<ControleBala>().DirecaoBala(-1);
        }
        else {
            pontoDisparo = new Vector3(
                transform.position.x + 1f,
                transform.position.y + 0.2f,
                transform.position.z);
            GameObject BalaDisparada = Instantiate(Bala, pontoDisparo, Quaternion.identity);
            BalaDisparada.GetComponent<ControleBala>().DirecaoBala(1);
        }
        
    }
    
   
    void Dano()
    {
        if (pode_dano == false)
        {
            temporizadorDano();
        }
    }
    void temporizadorDano()
    {
        meuTempoDano += Time.deltaTime;
        if (meuTempoDano > 0.25f)

        {
            pode_dano = true;
            meuTempoDano = 0;
            ImagemPersonagem.color = UnityEngine.Color.white;


        }
    }
    void Perderhp()
    {
        //barrahp.rectTransform.sizeDelta = new Vector2(vida*105.4269f, 106.72f);
        // int vida_parabarra = vida * 35;
        //barrahp.fillAmount = (float)vida / vidamax;
        barrahp[vida].gameObject.SetActive(false);
    }
    void Morrer()
    {
        
        Reiniciar();
    }
    void Reiniciar()
    {
        SceneManager.LoadScene(5);
    }
}
