using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.Events;
public enum Speeds { Slow = 0, Normal = 1, Fast = 2, Faster = 3, Fastest = 4 }
//public enum Gamemodes{Cube = 0, Ship = 1}
public class PlayerMovement : MonoBehaviour
{

    //**SCRIPT PRINCIPAL DEL PERSONAJE


    private Rigidbody2D rb;
    public float velocidad = 3f;
    public float multiplicador = 10f;
    public float multiplicadorSalto = 5f; //Controla la fuerza del salto.
    private bool puedoSaltar = true;
    GameObject respawn;
    private bool mirandoDerecha = true;
    private Animator animatorController;

    private bool estoymuerto;

    public bool controlActivo = false; // Se activa cuando quieres que el jugador se controle con teclas
    public float velocidadMovimiento = 3f; // Velocidad lateral con A/D

    //**musica para el salto**//
    AudioManagerScript audioManager;

    //**NUEVO -- VARIABLES DE LAS DIFERENTES VARIABLES DEL JUGADOR
    public Speeds currentSpeed;
    //                      0      1      2       3      4
    float[] SpeedValues = { 1.6f, 4.9f, 6.4f, 5.6f, 6.27f };


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();


        animatorController = this.GetComponent<Animator>();

        respawn = GameObject.Find("Respawn"); //acede al objeto
        transform.position = respawn.transform.position;

    }
    void Update()
    {
        // *** MOVIMIENTO CONSTANTE A LA DERECHA
        //si pones el current speed en normal, eso eaquivale al orden 1, que es igual a 10.4f
        if (controlActivo == false)
        {
            transform.position += Vector3.right * SpeedValues[(int)currentSpeed] * Time.deltaTime;
        }

        // *** MOVIMIENTO CONSTANTE A LA DERECHA
        //si pones el current speed en normal, eso eaquivale al orden 1, que es igual a 10.4f
        if (controlActivo == false)
        {
            transform.position += Vector3.right * SpeedValues[(int)currentSpeed] * Time.deltaTime;
        }

        // ***SALTO ---> 
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.5f); //En hit se guarda la ino. En Physics2D.Raycast → Lanza un rayo en 2D.(desde la pos.pj haacia abajo con una dist de 2 unidades)

        if (hit)
        {
            
            puedoSaltar = true;
        }
        else
        {
            puedoSaltar = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && puedoSaltar)
        {
            rb.AddForce(new Vector2(0, multiplicadorSalto), ForceMode2D.Impulse);
            AudioManagerScript.Instance.SuenaClip(AudioManagerScript.Instance.s_Salto);
        }
        else
        {
            puedoSaltar = false;
        }

        // ***COMPROBAR SI ME HE SALIDO DE LA PANTALLA (POR ABAJO)  ***//
        if (transform.position.y <= -40)
        {
            Respawnear();
        }
        // ***EN EL CASO DE ANDAR ***//
        if (controlActivo == true)
        {
            float movTeclas = Input.GetAxisRaw("Horizontal"); // -1 (A), 0, 1 (D)
            rb.velocity = new Vector2(movTeclas * multiplicador, rb.velocity.y);

            if (movTeclas < 0)
            {
                mirandoDerecha = false;
             
            }else
            {
                mirandoDerecha = true;
                
            }
            this.GetComponent<SpriteRenderer>().flipX = !mirandoDerecha;

    

            // ***ANIM WALKING ---> ***//
            if (movTeclas != 0)
            {
                animatorController.SetBool("activaCaminar", true);
            }
            else
            {
                animatorController.SetBool("activaCaminar", false);
            }

        }
    }

  


    //** al ejecutar esta funcion cambia el estado del speed al elegido
    public void ChangeThroughPortal(Speeds Speed)
    {
        currentSpeed = Speed;
        //Debug.Log("Velocidad cambiada a: " + newSpeed);

    }


    // *** RESPAWN QUE TE QUITA UNA VIDA Y SE LO COMUNICA AL GAMEMANAGER***//
    public void Respawnear()
    {

        //Debug.Log("vidas: "+GameManager.vidas);

        GameManager.vidas = GameManager.vidas - 1;

        Debug.Log("vidas: " + GameManager.vidas);

        transform.position = respawn.transform.position;
    }


    public void PreparadoParaAndar()
    {
        controlActivo = true;
        animatorController.SetBool("activaParado", true);
    }


  // *** emparentar balsa***//
public void EmparentarBalsa(Transform nuevaPlataforma){
    transform.SetParent(nuevaPlataforma);
}

}

















