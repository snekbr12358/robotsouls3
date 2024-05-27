using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransferir : MonoBehaviour
{
    public string sceneNome;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TransferToScene();
        }
    }
    public void TransferToScene()
    {
        SceneManager.LoadScene(sceneNome);
    }
}
