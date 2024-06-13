using UnityEngine;

public class MiraSeguirPlayer : MonoBehaviour
{
    public float velocidade = 5.0f; 
    private Transform playerTransform;

    public float delayDano = 1.0f;
    public   float contadorDano;

    void Start()
    {
      
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        
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
    }
    private void OnTriggerStay2D(Collider2D stay)
    {
        
        if (stay.CompareTag("Player"))
        {
            contadorDano += Time.deltaTime;
            if (contadorDano > delayDano)
            {
                
                stay.GetComponent<Persogem>().ReceberDano(1); 
                contadorDano = 0;
            }
        }


    }
}
