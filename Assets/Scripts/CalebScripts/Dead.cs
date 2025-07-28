using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
   //**Script que se añade a lo sobjetos que te dañan, llama al PlayerMovement.Respawnear
      private GameObject personaje; 
      private PlayerMovement PlayerMovement;

    void Start()
    {
        personaje = GameObject.Find("Player");
        PlayerMovement = personaje.GetComponent<PlayerMovement>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
       

        if (col.name == "Player")
        {

            Debug.Log("he colisionado, me quito una vida del gameManager");
            GameManager.vidas -= 1;
            //PlayerMovement.Respawnear();
        
        }
    }
}


        

        

           
        



