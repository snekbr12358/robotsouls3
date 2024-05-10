using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBoss : MonoBehaviour
{
    bool morreu = false;

    public int vida = 50;

    Animator animator;
    private SpriteRenderer ImagemLamp;

    // Start is called before the first frame update
    void Start()
    {
        ImagemLamp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        if (!morreu);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("vida",vida);
    }
    public void LevarDano(int dano)
    { 
        vida -= dano;
        StartCoroutine("Vermelhinho");
        if (vida <= 0)
        {
            
        }       
    }
    IEnumerator Vermelhinho()
    {
        ImagemLamp.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        ImagemLamp.color = Color.white;
    }
}
