using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InicioUI : MonoBehaviour
{
    public GameObject creditosPanel;

    public GameObject PausePanel;
    AudioManagerScript audioManager;

    void Start()
    {
        creditosPanel.SetActive(false);
        PausePanel.SetActive(false);
    }
    public void CargarEscenaLobby()
    {
        AudioManagerScript.Instance.SuenaClip(AudioManagerScript.Instance.s_MenuPausa);
        SceneManager.LoadScene("BaseCientifica");
    }
    public void CargarEscenaVideoIntro()
    {
        AudioManagerScript.Instance.SuenaClip(AudioManagerScript.Instance.s_MenuPausa);
        SceneManager.LoadScene("VideoInicio");
    }

    public void SalirJuego()
    {
        Debug.Log("he salido del juego");
        Application.Quit();
    }

    public void ActivoOpcionesPanel()
    {
        PausePanel.SetActive(true);
        AudioManagerScript.Instance.SuenaClip(AudioManagerScript.Instance.s_MenuPausa);
    }

    public void DesactivoOpcionesPanel()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        AudioManagerScript.Instance.SuenaClip(AudioManagerScript.Instance.s_MenuPausa);
    }
    public void ActivoCreditosPanel()
    {
        creditosPanel.SetActive(true);
        AudioManagerScript.Instance.SuenaClip(AudioManagerScript.Instance.s_MenuPausa);
    }

    public void DesactivoCreditosPanel()
    {
        creditosPanel.SetActive(false);
        Time.timeScale = 1f;
        AudioManagerScript.Instance.SuenaClip(AudioManagerScript.Instance.s_MenuPausa);
    }
    
}
