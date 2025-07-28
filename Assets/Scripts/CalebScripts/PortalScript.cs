using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{

      //**NUEVO -- AL HACER TRIGGER EL JUGADOR CON ESTE OBJETO, CAMBIARÁ LA VELOCIDAD DEL JUGADOR A LA QUE LE INDIQUE MANUALMENTE EN EL INSPECTOR

    public Speeds Speed;
 
    void OnTriggerEnter2D(Collider2D col)
    {
        PlayerMovement movement = col.gameObject.GetComponent<PlayerMovement>();

        if (col.name == "Player")
        {
            movement.ChangeThroughPortal(Speed);
        }
    }
    
}
