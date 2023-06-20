using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Persogem : MonoBehaviour
{
    public Rigidbody2D Corpo;
    public float velocidade;
    public int qtd_pulo = 0;
    private float meuTempoPulo = 0;
    public LayerMask groundLayer;
    
    

    //Componete SpriteRenderer
    public SpriteRenderer ImagemPersonagem;
    //Componet Bala
    public GameObject bullet;

    public GameObject idle_icon;

    //vida do personagem
    public int vida = 50;
    private float meuTempoDano = 0;
    public bool pode_pular = true;

    Animator animator;

    //barra de hp
    private bool pode_dano = true;
    private Image barrahp;

 
    



    // Start is called before the first frame update
    void Start()
    {
        barrahp = GameObject.FindGameObjectWithTag("hp_barra").GetComponent<Image>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        Apontar();
        Pular();
        Shoot();
        Dano();
    }
    void Mover()
    {
        velocidade = Input.GetAxis("Horizontal") * 5;
        if(Mathf.Abs(velocidade)> 0)
        {
            idle_icon.SetActive(false);
            animator.SetBool("Andar", true);
        }
        else
        {
            idle_icon.SetActive(true);
            animator.SetBool("Andar", false);
        }
        Corpo.velocity = new Vector2(velocidade, Corpo.velocity.y); 
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

    void OnTriggerEnter2D(Collider2D gatilho)
    {
        if (gatilho.gameObject.tag == "chao")
        {
            qtd_pulo = 0;
            pode_pular = true;
            meuTempoPulo = 0; 

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
                ImagemPersonagem.color = UnityEngine.Color.red;
                meuTempoDano = 0;
                //só morro se minha vida for menor ou igual a 0
                if (vida <= 0)
                {
                    Morrer();
                }
            }
        }


    }
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
           Instantiate(bullet, this.transform.position, this.transform.rotation);
            Disparor();
        }
    }
    void Disparor()
    {
        if (ImagemPersonagem.flipX == true)
        {
            Vector3 pontoDisparo = new Vector3(transform.position.x  + 0.3f, transform.position.y, transform.position.z);
            GameObject balaDisparo = Instantiate(bullet,pontoDisparo,Quaternion.identity);
            balaDisparo.GetComponent<ControleBala>().DirecaoBala(0.03f);
            Destroy(balaDisparo, 0.1f);
        }
        if (ImagemPersonagem.flipX == false)
        {
            Vector3 pontoDisparo = new Vector3(transform.position.x - 0.3f, transform.position.y, transform.position.z);
            GameObject balaDisparo = Instantiate(bullet, pontoDisparo, Quaternion.identity);
            balaDisparo.GetComponent<ControleBala>().DirecaoBala( -0.03f);
            Destroy(balaDisparo, -0.1f);
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
        barrahp.rectTransform.sizeDelta = new Vector2(vida*35, 35);
        // int vida_parabarra = vida * 35;
        
    }
    void Morrer()

    {
        SceneManager.LoadScene(1);

    }
}
