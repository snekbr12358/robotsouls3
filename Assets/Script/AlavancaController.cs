 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlavancaController : MonoBehaviour
{
    Animator animator;
    public GameObject aboboda;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetBool("Ativada", true);
            if (!aboboda.activeSelf) 
            {
                //colocar logica de acabar o jogo
            }
        }
    }

    public void DesativarEscudo() 
    { 
        aboboda.SetActive(false);
    }

}
