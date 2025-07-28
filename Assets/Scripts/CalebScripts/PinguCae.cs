using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinguCae : MonoBehaviour
{
    private GameObject personaje;

    // Start is called before the first frame update
    void Start()
    {
       personaje = GameObject.Find("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

       void OnTriggerEnter2D(Collider2D col) 
    {
        PlayerMovement pmov= col.GetComponent<PlayerMovement>();

        if(col.name == "Player"){
            Debug.Log("me he caido");
            pmov.Respawnear();
        }
       
    }

}
