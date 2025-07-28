using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalsaParada : MonoBehaviour
{
   private GameObject balsa;
 

   
    void Start()
    {
      
        balsa = GameObject.Find("balsa");
    }

 

     private void OnTriggerEnter2D(Collider2D col)
{
     Debug.Log("Algo entró al trigger: " + col.name);
    if (col.name == "balsa")
    {
        Debug.Log("La balsa entró al trigger, la balsa ya no puede moverse");
        col.GetComponent<PlataformaMovil>().puedeMoverse = false;
    }
}
}
