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
    
    public VidaBoss lampada1;
    public VidaBoss lampada2;

    public GameObject Mira;

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
            VerificarVidaLampadas();
        }
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

            if (Mira != null)
            {
                Destroy(Mira);
            }
        }
    }


    //IEnumerator Vermelhinho()
    //{
    //    ImagemBoss.color = Color.red;
    //    yield return new WaitForSeconds(0.5f);
    //    ImagemBoss.color = Color.white;
    //}

}
