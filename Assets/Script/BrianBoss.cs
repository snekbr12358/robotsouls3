using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainBoss : MonoBehaviour
{
    public AlavancaController alavanca;
    public AtivarBarreira Barreira;

    Animator animator;
    
    private SpriteRenderer ImagemBoss;
    bool morreu = false;

    public int vida = 50;
    
    public VidaBoss2 Vida1;
    public VidaBoss2 Vida2;

    public GameObject Mira;
    public GameObject Brilho;

    // Start is called before the first frame update
    void Start()
    {
        ImagemBoss = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!morreu)
        {      
            VerificarVida();
        }
    }
    

    void VerificarVida()
    {
        if (Vida1.vida <= 0 && Vida2.vida <= 0)
        {

            morreu = true;
            if (Mira != null)
            {
                Destroy(Mira);
            }           
            if (Brilho != null)
            {
                Destroy(Brilho, 1f);
            }
            alavanca.DesativarEscudo();
            ImagemBoss.color = Color.white;
            
           
        }
    }


    //IEnumerator Vermelhinho()
    //{
    //    ImagemBoss.color = Color.red;
    //    yield return new WaitForSeconds(0.5f);
    //    ImagemBoss.color = Color.white;
    //}

}
