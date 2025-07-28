using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnEnLobby : MonoBehaviour
{
    public string nombrePuntoRespawn = "RespawnDesdeMJBuceo"; // Este es el nombre del GameObject vacío en el Lobby

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerPrefs.SetString("PuntoRespawn", nombrePuntoRespawn); // Guarda el nombre del punto

            //AudioManagerScript.Instance.SuenaClip(AudioManagerScript.Instance.s_CambioEscena);
            SceneManager.LoadScene("Lobby"); // o "Lobby"
        }
    }
}