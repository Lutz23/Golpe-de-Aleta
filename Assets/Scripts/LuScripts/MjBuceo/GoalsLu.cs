using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalsLu : MonoBehaviour
{
   
     //**RECOGE PECES Y LO MUESTRA EN EL MARCADOR
    public int valor = 1;
   AudioManagerScript audioManager;
   


    void OnTriggerEnter2D(Collider2D col)
    {
         if(col.CompareTag("Player")){


           // GameManager.marcador = GameManager.marcador+valor;
            GameManager.marcadorPeces = GameManager.marcadorPeces+valor;

            Debug.Log("peces:"+ valor);
            this.GetComponent<Animator>().SetBool("destruirPeces", true);

            AudioManagerScript.Instance.SuenaClip(AudioManagerScript.Instance.s_RecogerPez);
       
            


            Destroy(this.gameObject, 1.0f);


        }


    }
   
    }




