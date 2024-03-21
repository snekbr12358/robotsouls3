using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GerenciadorJogo : MonoBehaviour
{
    public GameObject audioListener;

    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;

    public bool GameLigado = false;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        //Pausa os scripts
        GameLigado = true;
        //Pausa Fisica do Jogo
        Time.timeScale = 1;
    }

    public void IniciarJogo() 
    {
       SceneManager.LoadScene(0);
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        PauseMenu();

    }
    public bool EstadoDoJogo()
    {
        return GameLigado;
    }
    public void LateUpdate()
    {
        //GameLigado = true;
        //Time.timeScale = 1;
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
        SceneManager.LoadScene(5);
    }
    public void AbrirOpcoes() 
    {
        SceneManager.LoadScene(3);
    }
    public void FecharOpçoes()
    {
        SceneManager.LoadScene(1);
    }
   
    public void Creditos()
    {
        SceneManager.LoadScene(4);
    }
    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }

    public void PauseMenu()
    {
        if (pauseMenu.gameObject.activeSelf)
        {
            pauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
            GameLigado = true;
            audioListener.SetActive(true);
        }
        else
        {
            pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
            GameLigado = false;
            audioListener.SetActive(false);
        }
    }
    public void FecharPause()
    {
        SceneManager.LoadScene(1);
    }
}
