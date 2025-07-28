using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaManager : MonoBehaviour
{

    public GameObject panelpausa;


    void Start()
    {
        panelpausa.SetActive(false);

    }


    public void ActivoPausePanel()
    {
        panelpausa.SetActive(true);
        Time.timeScale = 0f;
        AudioManagerScript.Instance.SuenaClip(AudioManagerScript.Instance.s_MenuPausa);
    }
    public void DesactivoPausaPanel()
    {
        panelpausa.SetActive(false);
        Time.timeScale = 1f;
        AudioManagerScript.Instance.SuenaClip(AudioManagerScript.Instance.s_MenuPausa);
    }

    public void CargarEscenaLobby()
    {
        AudioManagerScript.Instance.SuenaClip(AudioManagerScript.Instance.s_MenuPausa);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Lobby");
        GameManager.vidas = 3;

    }
    
        public void CargarEscenaStart()
    {
        AudioManagerScript.Instance.SuenaClip(AudioManagerScript.Instance.s_MenuPausa);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start");
        GameManager.vidas = 3;
   
    }

    
}
