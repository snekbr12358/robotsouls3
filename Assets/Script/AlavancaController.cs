 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlavancaController : MonoBehaviour
{
    public GameObject aboboda;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
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
