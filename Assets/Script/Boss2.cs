using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    bool morreu = false;
    [SerializeField] private SpriteRenderer ImagemVida;
    [SerializeField] private SpriteRenderer ImagemVida2;
    public int vida = 6;

    void Start()
    {
        
    }
    private void Update()
    {
        if (!morreu);
    }

    public void LevarDano(int dano)
    {
        vida -= dano;
        StartCoroutine("Vermelhinho");
        if (vida <= 0)
        {
            morreu = true;
            Destroy(gameObject, 0.7f);

        }
    }

    IEnumerator Vermelhinho()
    {
        ImagemVida.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        ImagemVida.color = Color.white;
    }
}

