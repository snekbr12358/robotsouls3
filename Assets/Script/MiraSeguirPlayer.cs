using UnityEngine;
using UnityEngine.U2D;

public class MiraSeguirPlayer : MonoBehaviour
{
    public float velocidade = 5.0f; 
    private Transform playerTransform;

    public float delayDano = 1.0f;
    public   float contadorDano;

    SpriteRenderer sprite;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.green;
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Jogador com a tag 'Player' não encontrado!");
        }
    }

    void Update()
    {

        if (playerTransform != null)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z), velocidade * Time.deltaTime);
        }

        float t = contadorDano/delayDano;

        sprite.color = Color.Lerp(Color.green, Color.red, t);

    }
    private void OnTriggerStay2D(Collider2D stay)
    {
        
        if (stay.CompareTag("Player"))
        {
            contadorDano += Time.deltaTime;
            if (contadorDano > delayDano)
            {
                sprite.color = Color.green;
                stay.GetComponent<Persogem>().ReceberDano(1); 
                contadorDano = 0;
            }
        }


    }
}
