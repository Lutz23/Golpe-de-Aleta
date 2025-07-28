using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameManagerBuceo : MonoBehaviour
{


    public static int score = 0;
    public static bool estoyMuerto = false;
    public static int marcador = 0;
    private GameObject vidasText;
    private GameObject scoreText;


    public static int vidas = 3;

     private GameObject cora1;
     private GameObject cora2;
     private GameObject cora3;

    AudioManagerScript audioManager;


 
    void Start()
    {
        //vidasText = GameObject.Find("TextVidas");
    scoreText = GameObject.Find("TextScore");

    cora1 = GameObject.Find("cora1");
    cora2 = GameObject.Find("cora2");
    cora3 = GameObject.Find("cora3");

    }


   
    void Update()
    {

      /*  if (Input.GetKeyDown(KeyCode.U)){ 
            cora1.SetActive(false);
        } */


        //**Actualización marcador PezMoneda
        //vidasText.GetComponent<TextMeshProUGUI> ().text = vidas.ToString();
        scoreText.GetComponent<TextMeshProUGUI> ().text = marcador.ToString();




         //**NUEVO -- Actualización de eliminar corazones
         if (vidas <=2 && cora3 != null)
        {
            Debug.Log("tengo 2 vidas y elimino corazon1");
            cora3.SetActive(false);
        }


        if (vidas <= 1 && cora2 != null)
        {


            Debug.Log("tengo 1 vidas loool");
                cora2.SetActive(false);
        }




        if (vidas == 0 && cora1 != null)
        {
             cora1.SetActive(false);
            Debug.Log("tengo 0 vidas y llamo a respawn");
            estoyMuerto = true;
            //respawn


        }
    }
}




