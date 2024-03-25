using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetornoScena : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica se qualquer botão do teclado ou mouse foi pressionado
        if (Input.anyKeyDown)
        {
            RetornaScene0();
        }

        void RetornaScene0()
        {
            // Carrega a cena 0
            SceneManager.LoadScene(0);
        }
    }
}
