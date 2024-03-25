using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntervaloCena : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject objectDesativado;
    public float intervalo = 10f;

    void Start()
    {
        // Inicia a repetição da chamada ao método PlayVideo a cada 10 segundos
        InvokeRepeating("PlayVideo", 0f, intervalo);
    }

    void PlayVideo()
    {
        // Verifica se o vídeo não está sendo reproduzido
        if (!videoPlayer.isPlaying)
        {
            // Reinicia a reprodução do vídeo a partir do início
            videoPlayer.Stop();
            videoPlayer.Play();
        }
        else
        {
            // Se o vídeo está sendo reproduzido, desativa o GameObject
            objectDesativado.SetActive(false);
        }
    }

    void OnDestroy()
    {
        // Cancela a repetição ao destruir o objeto
        CancelInvoke("PlayVideo");
    }
}