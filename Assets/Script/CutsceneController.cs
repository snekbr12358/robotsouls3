using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutsceneController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public int nextScene;

    void Start()
    {
        videoPlayer.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        LoadNextScene();
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica se qualquer botão do teclado ou mouse foi pressionado
        if (Input.anyKeyDown)
        {
            PulaCutScene();
        }
    }

    void PulaCutScene()
    {
        SceneManager.LoadScene(nextScene);
    }

}
