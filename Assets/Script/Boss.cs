using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private float velocidadeauto;
    private SpriteRenderer ImagemBoss;

    public int vida = 50;
    public float velocidade = 0.1f;
    public float distInicial = 0f;
    public float distFinal = 0f;
    public GameObject teladevitoria;
    // Start is called before the first frame update
    void Start()
    {
        ImagemBoss = GetComponent<SpriteRenderer>();

        velocidadeauto = velocidade;

    }

    // Update is called once per frame
    void Update()
    {
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
            ImagemBoss.flipX = false;
        }
        //Andar para frente
        if (transform.position.x < distInicial)
        {
            velocidadeauto = velocidade * 1f;
            ImagemBoss.flipX = true;
        }
    }
    public void LevarDano(int dano)
    {
        vida -= dano;
        StartCoroutine("Vermelhinho");
        if (vida <= 0)
        {
            teladevitoria.SetActive(true);
            Destroy(gameObject);
        }
    }

}
