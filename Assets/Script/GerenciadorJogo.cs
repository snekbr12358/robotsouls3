using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GerenciadorJogo : MonoBehaviour
{
    public bool GameLigado = false;
    // Start is called before the first frame update
    void Start()
    {
        //Pausa os scripts
        GameLigado = false;
        //Pausa Fisica do Jogo
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool EstadoDoJogo()
    {
        return GameLigado;
    }
    public void LateUpdate()
    {
        GameLigado = true;
        Time.timeScale = 1;
    }

    public void ChamarChena(int cena)
    {

        SceneManager.LoadScene(cena);

    }
    public void PersogemMorreu()
    {
        //Reiniciar o Jogo Nesse Momento
        void Reiniciar()
        {
            SceneManager.LoadScene(0);
        }
    }
}
