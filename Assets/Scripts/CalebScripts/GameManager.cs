using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static int score = 0; 
    public static int marcadorPeces = 0; 
    public static int marcadorMadera = 0; 
    public static int marcadorFotos = 0;    
    public static bool estoyMuerto = false;
    private GameObject vidasText;
    private GameObject scoreTextPez;
    private GameObject scoreTextMadera;

    public static bool haJugadoMinijuegoBuceo = false;
    public static bool liderYaSeMovio = false;

    public static int vidas = 3;
     private GameObject cora1;
     private GameObject cora2;
     private GameObject cora3;

    /* public static GameManager Instance; //Lu 26/05
    public bool hasBackpack = false; //Lu 26/05 */
    

     //**musica para el cuando desaparecen corazones**//
    AudioManagerScript audioManager;

   /*  void Awake() //Lu 26/05
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    } */




    void Start()
    {

     

    cora1 = GameObject.Find("cora1");
    cora2 = GameObject.Find("cora2");
    cora3 = GameObject.Find("cora3");

    
        //vidasText = GameObject.Find("TextVidas");
        scoreTextPez = GameObject.Find("TextScorePez");
        scoreTextMadera = GameObject.Find("TextScoreMadera");

         cora1 = GameObject.Find("cora1");
         cora2 = GameObject.Find("cora2");
         cora3 = GameObject.Find("cora3");
         
    }

   
    void Update()
    {

        //**Actualización marcador de madera
        //vidasText.GetComponent<TextMeshProUGUI> ().text = vidas.ToString();
         if (scoreTextPez != null)
            {
                scoreTextPez.GetComponent<TextMeshProUGUI>().text = marcadorPeces.ToString();
            }

        if (scoreTextMadera != null)
            {
                scoreTextMadera.GetComponent<TextMeshProUGUI>().text = marcadorMadera.ToString();
            }


        //**NUEVO -- Actualización de eliminar corazones
          if (vidas <= 2 && cora3.activeSelf) // solo si aún está activo
    {
        cora3.SetActive(false);
        AudioManagerScript.Instance.SuenaClip(AudioManagerScript.Instance.s_Muerte);
    }

    if (vidas <= 1 && cora2.activeSelf)
    {
        cora2.SetActive(false);
        AudioManagerScript.Instance.SuenaClip(AudioManagerScript.Instance.s_Muerte);
    }

        if (vidas <= 0)
        {
             if (cora1.activeSelf)
                cora1.SetActive(false);
            AudioManagerScript.Instance.SuenaClip(AudioManagerScript.Instance.s_Muerte);

            Debug.Log("Vidas agotadas. Cargando Lobby...");

            GameManager.vidas = 3;
            Time.timeScale = 1f;
            SceneManager.LoadScene("Lobby");
    }
    }
}
