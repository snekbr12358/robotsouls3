using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portas : MonoBehaviour
{
    [SerializeField]
    private string nomeProximaFase;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void IrProximaFase()
    {
        SceneManager.LoadScene(this.nomeProximaFase);
    }
}
