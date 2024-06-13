using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBoss2 : MonoBehaviour
{
    bool morreu = false;
    public int vida = 50;
    private SpriteRenderer ImagemLamp;

    // Start is called before the first frame update
    void Start()
    {
        ImagemLamp = GetComponent<SpriteRenderer>();
        if (!morreu);
    }

    // Update is called once per frame
    void Update()
    {
        
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
