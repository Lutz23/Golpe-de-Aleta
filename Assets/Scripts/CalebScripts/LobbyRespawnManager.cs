using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyRespawnManager : MonoBehaviour
{
    public GameObject jugador;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Lobby")
        {
            string puntoGuardado = PlayerPrefs.GetString("PuntoRespawn", "RespawnPorDefecto");
            GameObject punto = GameObject.Find(puntoGuardado);

            if (punto != null && jugador != null)
            {
                jugador.transform.position = punto.transform.position;
                Debug.Log("Jugador movido a punto de respawn en escena Lobby: " + punto.transform.position);
            }
            else
            {
                Debug.LogWarning("No se encontró el punto de respawn o jugador no asignado");
            }
        }
    }
}