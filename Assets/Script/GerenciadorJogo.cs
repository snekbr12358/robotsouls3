using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GerenciadorJogo : MonoBehaviour
{
    Vector2 checkpointPos;

    public GameObject audioListener;

    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;

    public bool GameLigado = false;
    public GameObject pauseMenu;

    public static GerenciadorJogo instance;
    public int playerHealth;
    public Vector2 playerPosition;


    // Start is called before the first frame update
    void Start()
    {
        checkpointPos = transform.position;

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
    public void UpdateCheckpoint(Vector2 pos) 
    {
        checkpointPos = pos;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SavePlayerData(int health, Vector2 position)
    {
        playerHealth = health;
        playerPosition = position;
    }

    public void LoadPlayerData(out int health, out Vector2 position)
    {
        health = playerHealth;
        position = playerPosition;
    }
}


