using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoIntro : MonoBehaviour
{
    public VideoPlayer videoIntro;
    public string sceneToLoad = "BaseCientifica";

    private bool videoFinalizado = false;

    void Awake()
    {
        videoIntro = GetComponent<VideoPlayer>();
        videoIntro.loopPointReached += CuandoTermineVideo;
        videoIntro.Play();
        StartCoroutine(EsperarYPasarEscena((float)videoIntro.length - 0.1f));
    }

    void Update()
    {
        if (!videoFinalizado && Input.GetMouseButtonDown(0))
        {
            // Saltar video con clic
            CambiarEscena();
        }
    }

    IEnumerator EsperarYPasarEscena(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        CambiarEscena();
    }

    void CuandoTermineVideo(VideoPlayer vp)
    {
        CambiarEscena();
    }

    void CambiarEscena()
    {
        if (!videoFinalizado)
        {
            videoFinalizado = true;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
