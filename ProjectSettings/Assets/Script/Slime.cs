using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public Rigidbody2D Corpo;
    public float velocidade = 0.01f;
    public float distinicial;
    public float distfinal;

    private int vida = 2;
    private SpriteRenderer imagemMob;


    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        Apontar();
    }
    void Mover()
    {
        velocidade = Input.GetAxis("Horizontal") * 5;
        if (Mathf.Abs(velocidade) > 0)
        {
            animator.SetBool("Andar", true);
        }
        else
        {
            animator.SetBool("Andar", false);
        }
        Corpo.velocity = new Vector2(velocidade, Corpo.velocity.y);
    }
    public void Dano()
    {
        vida--;
        if (vida < 0)
        {
            Destroy(gameObject);
        }
    }
    void Apontar()
    {
        if (velocidade > 0)
        {
            imagemMob.flipX = false;
        }
        if (velocidade < 0)
        {
            imagemMob.flipX = true;
        }
    } 
}
