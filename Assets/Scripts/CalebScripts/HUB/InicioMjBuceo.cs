using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InicioMjBuceo: MonoBehaviour
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
             //GameManager.haJugadoMinijuegoBuceo = true; // ✅ Marca que entró
            SceneManager.LoadScene("Mj_Buceo_Lu");
            //PlayerMovement.Respawnear();

        }
    }


}

