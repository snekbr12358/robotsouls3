using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public AlavancaController alavanca;
    public AtivarBarreira Barreira;

    Animator animator;
    private float velocidadeauto;
    private SpriteRenderer ImagemBoss;
    bool morreu = false;

    public int vida = 50;
    public float velocidade = 0.05f;
    public float distInicial = 0f;
    public float distFinal = 0f;

    [SerializeField] private bool paraFrente;
    [SerializeField] private float multiplicador;

    public VidaBoss lampada1;
    public VidaBoss lampada2;

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
        Debug.Log(velocidade);
        if (!morreu) { 
            Andar();
            VerificarVidaLampadas();
        }
    }
    void Andar()
    {
                                      
        //Andar para frente
        if (transform.position.x < distInicial)
        {            
            paraFrente = true;
            velocidade *= -1;
            Vector3 newScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            transform.localScale = newScale;
            //ImagemBoss.flipX = true;
        }
        //Andar para trás
        if (transform.position.x > distFinal)
        {
            paraFrente = false;
            velocidade *= -1;
            Vector3 newScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            transform.localScale = newScale; 
            //ImagemBoss.flipX = false;
        }
    
        transform.position = new Vector3(transform.position.x + velocidade * Time.deltaTime * multiplicador, transform.position.y, transform.position.z);
    }

    void VerificarVidaLampadas() 
    {
        if (lampada1.vida <= 0 && lampada2.vida <= 0) 
        {
            morreu = true;
            Destroy(gameObject, 1f);
            animator.SetBool("Morte", true);
            ImagemBoss.color = Color.white;
            alavanca.DesativarEscudo();
            Barreira.DesativarAposMorte();
        }
    }


    //IEnumerator Vermelhinho()
    //{
    //    ImagemBoss.color = Color.red;
    //    yield return new WaitForSeconds(0.5f);
    //    ImagemBoss.color = Color.white;
    //}

}
