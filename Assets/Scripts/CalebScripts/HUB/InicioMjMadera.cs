using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InicioMadera: MonoBehaviour
{
    private GameObject personaje;


    void Start()
    {
         personaje = GameObject.FindWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D col)
    {


        if (col.CompareTag("Player"))
        {

            Debug.Log("voy a la escena fotos");
            SceneManager.LoadScene("MJ_madera");
            //PlayerMovement.Respawnear();

            //en la escena fotos poner al final un collider invisible con elscript de Respawn en Lobby y el nombre de RespawnDesdeMJMadera para que Respawnee en el punto exaco

        }
    }


}

