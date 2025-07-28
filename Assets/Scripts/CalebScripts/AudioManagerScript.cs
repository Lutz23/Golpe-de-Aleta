using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManagerScript : MonoBehaviour
{
  //**AduioSource
  public AudioSource m_audioSource;
  public AudioSource m_sfx;
  //**musica de fondo
  public AudioClip bandaSonora;

  
    [Header("Músicas de fondo")]
    public AudioClip musicaBaseCientifica;
    public AudioClip musicaLobby;
    public AudioClip musicaMJBuceo;
    public AudioClip musicaMJMadera;
    public AudioClip musicaMJFotos;

  //**Aquivan los nombres s_nombre de los sonidos que queremos añadir, luego se añaden desde el inspectar
  //**sonidos mjMadera
  public AudioClip s_RecogerMadera;
  public AudioClip s_Dialogo;
  public AudioClip s_Salto;
  //**sonidos mBuceo
  public AudioClip s_RecogerPez;
  public AudioClip s_SonidoBalaBuceo;
  public AudioClip s_EnemigoMuere;
  public AudioClip s_Muerte;
  public AudioClip s_MenuPausa;
  public AudioClip s_CambioEscena;
  public AudioClip s_ClickFoto;



  //**no se para que es esto de musiObj
  //public GameObject musicObj;

  public static AudioManagerScript Instance;
  // Start is called before the first frame update
  //* para que en cuanto se despierte el objeto no destruya este objeto (la musica,  así seguirá la música mientras juegas)
void Awake()
    {
      Debug.Log("Awake AudioManager en: " + gameObject.name);

        if (Instance != null && Instance != this)
    {
      Destroy(this.gameObject);
    }
    else
    {
      Instance = this;
      DontDestroyOnLoad(this.gameObject);
    }
    
        if (m_sfx != null)
    {
        m_sfx.ignoreListenerPause = true;
    }

    

        // Escuchar cambio de escena
    SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        // Música inicial
        CambiarMusicaPorEscena(SceneManager.GetActiveScene().name);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CambiarMusicaPorEscena(scene.name);
    }

    void CambiarMusicaPorEscena(string nombreEscena)
{
    Debug.Log("Cambiando música para la escena: " + nombreEscena);
    AudioClip musicaEscena = null;

    switch (nombreEscena)
    {
        case "PruebasCaleb":
            musicaEscena = musicaLobby;
            break;
        case "BaseCientifica":
            musicaEscena = musicaBaseCientifica;
            break;
        case "MJ_Fotos":
            musicaEscena = musicaMJFotos;
            break;
        case "Mj_Buceo_Lu":
            musicaEscena = musicaMJBuceo;
            break;
        case "MJ_madera":
            musicaEscena = musicaMJMadera;
            break;
        default:
            musicaEscena = musicaLobby;
            break;
    }

    if (musicaEscena != null && m_audioSource.clip != musicaEscena)
    {
        Debug.Log("Reproduciendo música: " + musicaEscena.name);
        m_audioSource.Stop();
        m_audioSource.clip = musicaEscena;
        m_audioSource.Play();
    }
    else
    {
        Debug.LogWarning("No se encontró música para esta escena o ya se está reproduciendo.");
    }
}

  //*método para hacer el sonido
  public void SuenaClip(AudioClip miClipDeAudio)
  {
    m_sfx.PlayOneShot(miClipDeAudio);
  }
}
