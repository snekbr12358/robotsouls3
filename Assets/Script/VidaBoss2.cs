using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBoss2 : MonoBehaviour
{
    bool morreu = false;
    public int vida = 50;
    private SpriteRenderer ImagemVida;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        ImagemVida = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LevarDano(int dano)
    {
        vida -= dano;
        if (vida <= 0)
        {
            StartCoroutine("Vermelhinho");
            animator.SetBool("Morte", true);
        }

    }
    IEnumerator Vermelhinho()
    {
        ImagemVida.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        ImagemVida.color = Color.white;
    }
}
