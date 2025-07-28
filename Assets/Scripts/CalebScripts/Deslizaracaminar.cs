using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deslizaracaminar : MonoBehaviour
{
    //**es necesario poner referencia privada del personaje aunque no la llames?
    private GameObject personaje;

    private void Start()
    {
        personaje = GameObject.Find("Player");
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            PlayerMovement movimiento = col.GetComponent<PlayerMovement>();
            if (movimiento != null)
            {
                movimiento.PreparadoParaAndar();

            }
        }
    }
}
