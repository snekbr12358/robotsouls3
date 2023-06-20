using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AranhaA : MonoBehaviour
{
    private float velocidadeauto;
    private SpriteRenderer ImagemAranhaA;

    public int vida = 6;
    public float velocidade = 0.1f;
    public float distInicial = 0f;
    public float distFinal = 0f;
    // Start is called before the first frame update
    void Start()
    {
        ImagemAranhaA = GetComponent<SpriteRenderer>();

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
            ImagemAranhaA.flipX = false;
        }
        //Andar para frente
        if (transform.position.x < distInicial)
        {
            velocidadeauto = velocidade * 1f;
            ImagemAranhaA.flipX = true;
        }
    }
    public void LevarDano(int dano)
    {
        vida -= dano;
        StartCoroutine("Vermelhinho");
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
