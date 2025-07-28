using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalFotos : MonoBehaviour
{
    private GameObject personaje;
    private bool isPlayerinRange;
    // Start is called before the first frame update
    void Start()
    {
        personaje = GameObject.Find("Player");
    }

void OnTriggerEnter2D(Collider2D col)
    {


        if (col.name == "Player")
        {

            Debug.Log("voy a la escena fotos");
            SceneManager.LoadScene("MJ_Fotos");
            GameManager.vidas = 3;
            //PlayerMovement.Respawnear();

        }
    }
   
   

    // public void InicioStart(){
    //     SceneManager.LoadScene("4_Escena1");
    // }
}

