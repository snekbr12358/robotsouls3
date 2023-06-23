using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aranha : MonoBehaviour
{
    Animator animator;
    private float velocidadeauto;
    private SpriteRenderer ImagemAranha;
    bool morreu = false;

    public int vida = 6;
    public float velocidade = 0.1f;
    public float distInicial = 0f;
    public float distFinal = 0f;
    // Start is called before the first frame update
    void Start()
    {

        ImagemAranha = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        velocidadeauto = velocidade;

    }

    // Update is called once per frame
    void Update()
    {
        if (!morreu)
            Andar();
    }
    void Andar()
    {
        transform.position = new Vector3(transform.position.x + velocidadeauto, transform.position.y, transform.position.z);
        //mudar velocidade
        //Andar para trás
        if (transform.position.x > distFinal)
        {
            velocidadeauto = velocidade * -1f;
            ImagemAranha.flipX = false;
        }
        //Andar para frente
        if (transform.position.x < distInicial)
        {
            velocidadeauto = velocidade * 1f;
            ImagemAranha.flipX = true;
        }
    }
    public void LevarDano(int dano)
    {
        vida -= dano;
        StartCoroutine("Vermelhinho");
        if (vida <= 0)
        {
            morreu = true;
            Destroy(gameObject, 0.7f);
            animator.SetBool("Morte", true);
            ImagemAranha.color = Color.white;
        }
    }
    IEnumerator Vermelhinho()
    {
        ImagemAranha.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        ImagemAranha.color = Color.white;
    }
}
