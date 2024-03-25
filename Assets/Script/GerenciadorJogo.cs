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

    public float sceneTrocaIntervalo = 15f; // Intervalo de troca de cena em segundos
    private float timer = 0f;


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
        // Verifica se o jogador está na cena 0
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            timer += Time.deltaTime;

            // Se o temporizador atingir o intervalo, muda para a próxima cena
            if (timer >= sceneTrocaIntervalo)
            {
                TrocaProxCena();
                timer = 0f; // Reseta o temporizador
            }
        }
       
        if (Input.GetKeyDown(KeyCode.Escape))
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
        SceneManager.LoadScene(0);
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
        SceneManager.LoadScene(0);
    }
    void TrocaProxCena()
    {
        // Obtém o índice da próxima cena
        int nextSceneIndex = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;

        // Carrega a próxima cena
        SceneManager.LoadScene(nextSceneIndex);
    }
  
}
