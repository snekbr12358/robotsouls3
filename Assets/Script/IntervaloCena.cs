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
        // Inicia a repeti��o da chamada ao m�todo PlayVideo a cada 10 segundos
        InvokeRepeating("PlayVideo", 0f, intervalo);
    }

    void PlayVideo()
    {
        // Verifica se o v�deo n�o est� sendo reproduzido
        if (!videoPlayer.isPlaying)
        {
            // Reinicia a reprodu��o do v�deo a partir do in�cio
            videoPlayer.Stop();
            videoPlayer.Play();
        }
        else
        {
            // Se o v�deo est� sendo reproduzido, desativa o GameObject
            objectDesativado.SetActive(false);
        }
    }

    void OnDestroy()
    {
        // Cancela a repeti��o ao destruir o objeto
        CancelInvoke("PlayVideo");
    }
}