using Cinemachine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Persogem : MonoBehaviour
{


    [Header("MUDAR!")]
    public int currentLevelIndex;

    public RuntimeAnimatorController animatorCanhaoPrefab;

    public GameObject iconeCanhao;

    public Rigidbody2D Corpo;
    public float forcapulo;
    public float velocidade;
    public float speed;
    public int qtd_pulo = 0;
    private float meuTempoPulo = 0;

    public float velocidadeBala;

    //Componete SpriteRenderer
    public SpriteRenderer ImagemPersonagem;
    //Componet Bala
    public GameObject Bala;


    //Conponet Icon
    public GameObject idle_icon;

    //vida do personagem
    public int vida = 50;
    int vidamax;
    private float meuTempoDano = 0;
    public bool pode_pular = true;

    public Animator animator;

    //barra de hp
    private bool pode_dano = true;
    public Image[] barrahp;

    //Moeda
    public int moedas = 0;
    private Text Moeda_texto;

    public GerenciadorJogo GJ;

    bool direita;

   public bool Armado = false;

    CinemachineVirtualCamera cameraVirtualPlayer;

    float tempoIdle;
    [SerializeField]float contadorIdle;

    public ColetarItem coletorDeItens;


    // Start is called before the first frame update
    void Start()
    {
        SaveGameState(currentLevelIndex);

        Vector3 spawnPosition = LoadGameState(currentLevelIndex);

        if (Armado) 
        {
            animator.runtimeAnimatorController = animatorCanhaoPrefab;
        }

        // Define a posição inicial do jogador com base na posição carregada.
        transform.position = spawnPosition;

        coletorDeItens = GetComponent<ColetarItem>();

        //Moeda_texto = GameObject.FindGameObjectWithTag("Moeda_texto_tag").GetComponent<Text>();
        //barrahp = GameObject.FindGameObjectWithTag("hp_barra").GetComponent<Image>();
        animator = GetComponent<Animator>();
        GJ = FindObjectOfType<GerenciadorJogo>();
        cameraVirtualPlayer = FindObjectOfType<CinemachineVirtualCamera>();
        vidamax = vida;
    }


    // Update is called once per frame
    void Update()
    {
        if (GJ.EstadoDoJogo()) 
        { 
            Mover();
            Apontar();
            Pular();
            Atirar();
            Dano();
            Debug.Log("Player!:"+Corpo.velocity.magnitude);
            if (Corpo.velocity.magnitude <= 0)
            {
                contadorIdle += Time.deltaTime;
                if (contadorIdle > 5)
                {
                    contadorIdle = 0;
                    idle_icon.SetActive(true);
                }
            }
            else 
            {
                contadorIdle = 0;
                idle_icon.SetActive(false);
            }
        }
    }
    void Mover()
    {
        velocidade = Input.GetAxis("Horizontal") * speed;

        Corpo.velocity = new Vector2(velocidade, Corpo.velocity.y);

        if (Mathf.Abs(velocidade) > 0.3f)
        {
            animator.SetFloat("eixoh", velocidade);
        }

        if (Mathf.Abs(velocidade) > 0)
        {
            animator.SetBool("Andar", true);   
        }
        else
        {
            animator.SetBool("Andar", false);
        } 
    }
    void Apontar()
    {
        if(velocidade > 0)
        {
            direita = false;
            //ImagemPersonagem.flipX = false;
        }
        if(velocidade < 0)
        {
            direita = true;
            //ImagemPersonagem.flipX = true;
        }
    }
    void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump") && pode_pular == true)
        {
            animator.SetBool("Pula", true);
            pode_pular = false;
            qtd_pulo++;
            if (qtd_pulo <= 2)
                AcaoPulo();
        }
        if(pode_pular == false)
        {
            TemporizadorPulo();
        }
    }
    void AcaoPulo()
    {
        //Corpo.velocity = new Vector2(velocidade, 0);
        Corpo.AddForce(Vector2.up * forcapulo);
    }
    //Gatilhos
    void OnTriggerEnter2D(Collider2D gatilho)
    {
        if (gatilho.gameObject.tag == "chao")
        {
            animator.SetBool("Pula", false);
            qtd_pulo = 0;
            pode_pular = true;
            meuTempoPulo = 0; 

        }    
        if (gatilho.gameObject.tag == "Canhao")
        {
            Armado = true;
           
        }     
    }
    
    
    //Tempo de Pulo
    void TemporizadorPulo()
    {
        meuTempoPulo += Time.deltaTime;
        if (meuTempoPulo > 0.5)
        {
            pode_pular =true;
            meuTempoPulo = 0;
        }
    }


    // Gatilhos
    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.tag == "Inimigo")
        {
            if (pode_dano == true)
            {
                StartCoroutine("CameraShake");
                vida--;
                Perderhp();
                pode_dano = false;
                //ImagemPersonagem.color = UnityEngine.Color.red;
                meuTempoDano = 0;
                animator.SetTrigger("Dano");
                //só morro se minha vida for menor ou igual a 0
                if (vida <= 0)
                {
                    Morrer();
                }
            }
        }

        if(colisao.gameObject.tag == "morte_imediata")
        {
            if(pode_dano == true)
            {
                pode_dano = false;
                vida = vida - 3;
                Perderhp();
                SceneManager.LoadScene(5);
            }
        }
        if (colisao.gameObject.tag == "Canhao") 
        {
            Armado = true;
            animator.runtimeAnimatorController = animatorCanhaoPrefab;
            colisao.gameObject.SetActive(false);
            StartCoroutine(AparecerDesaparecer(3, iconeCanhao));
        }
        if (colisao.gameObject.tag == "Item")
        {
            if(vida < 3)
                vida++;
            Destroy(colisao.gameObject);

            barrahp[vida-1].gameObject.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Persogem player = other.GetComponent<Persogem>();
            if (player != null)
            {
                player.Dano();
            }
        }
    }
    //Atira Balas
    void Atirar()
    {
        if ((Input.GetKeyDown(KeyCode.X) || Input.GetButtonDown("Fire1")) && Armado)
        {           
            animator.SetTrigger("Ataque");
           //Instantiate(Bala, this.transform.position, this.transform.rotation);
            Disparor();
        }
    }

    void Disparor()
    {
        Vector3 pontoDisparo = Vector3.zero;
        if (direita)
        {
            pontoDisparo = new Vector3(
                transform.position.x - 1f,
                transform.position.y ,
                transform.position.z);
            GameObject BalaDisparada = Instantiate(Bala, pontoDisparo, Quaternion.identity);
            BalaDisparada.GetComponent<ControleBala>().DirecaoBala(-1);
        }
        else {
            pontoDisparo = new Vector3(
                transform.position.x + 1f,
                transform.position.y + 0.2f,
                transform.position.z);
            GameObject BalaDisparada = Instantiate(Bala, pontoDisparo, Quaternion.identity);
            BalaDisparada.GetComponent<ControleBala>().DirecaoBala(1);
        }
        
    }


    IEnumerator AparecerDesaparecer(float qtd, GameObject go) 
    { 
        go.SetActive(true);
        yield return new WaitForSeconds(qtd);
        go.SetActive(false);
    }

    void Dano()
    {
        if (pode_dano == false)
        {
            temporizadorDano();
        }
    }

    IEnumerator CameraShake() 
    {
        cameraVirtualPlayer.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 2;
        cameraVirtualPlayer.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 2;
        yield return new WaitForSeconds(0.5f);
        cameraVirtualPlayer.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
        cameraVirtualPlayer.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0;
    }

    void temporizadorDano()
    {
        meuTempoDano += Time.deltaTime;
        if (meuTempoDano > 0.25f)
        {
            pode_dano = true;
            meuTempoDano = 0;
            ImagemPersonagem.color = UnityEngine.Color.white;
        }
    }
    void Perderhp()
    {
        //barrahp.rectTransform.sizeDelta = new Vector2(vida*105.4269f, 106.72f);
        // int vida_parabarra = vida * 35;
        //barrahp.fillAmount = (float)vida / vidamax;
        barrahp[vida].gameObject.SetActive(false);
    }
    void Morrer()
    {
        
        Reiniciar();
    }
    void Reiniciar()
    {
        SceneManager.LoadScene(5);
    }
    public void SaveGameState(int level)
    {
        PlayerPrefs.SetInt("CurrentLevel", level);
        PlayerPrefs.SetString ("Armado", Armado.ToString());
        PlayerPrefs.SetFloat("PlayerX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", transform.position.z);

        PlayerPrefs.Save(); // Garante que os dados sejam salvos imediatamente
    }

    Vector3 LoadGameState(int level)
    {
        int savedLevel = PlayerPrefs.GetInt("CurrentLevel", -1);

        if (savedLevel == level)
        {
            float x = PlayerPrefs.GetFloat("PlayerX");
            float y = PlayerPrefs.GetFloat("PlayerY");
            float z = PlayerPrefs.GetFloat("PlayerZ");

            Armado = bool.Parse(PlayerPrefs.GetString("Armado"));

            return new Vector3(x, y, z);
        }
        else
        {
            return transform.position;
        }
    }

}
