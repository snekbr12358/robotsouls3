using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GerenciadorJogo : MonoBehaviour
{
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
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
      Reiniciar();
    }
    //Reinicia o Jogo
    void Reiniciar()
    {
        SceneManager.LoadScene(0);
    }
    public void AbrirOpcoes() 
    {
        SceneManager.LoadScene(3);
    }
    public void FecharOpçoes()
    {
        SceneManager.LoadScene(0);
    }
    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
    public void Creditos()
    {
        SceneManager.LoadScene(4);
    }
}
