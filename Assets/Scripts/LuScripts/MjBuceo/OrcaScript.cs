using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcaScript : MonoBehaviour
{
    Vector2 posicionInicial;
    GameObject Pingu01;

    public float velocidadEnemigoFast = 8.0f;
    public int vidaEnemigoFast = 2;

    public float moveThreshold = 10f;   // Distancia para nadar
    public float attackThreshold = 3f; // Distancia para atacar
    Animator anim;

    private SpriteRenderer spriteRenderer;  // Para voltear el sprite
    private Rigidbody2D rb;  // Para mover la orca utilizando Rigidbody2D

    void Start()
    {
        vidaEnemigoFast = 2;  // Fuerza a la Orca a estar viva al principio
        posicionInicial = transform.position;
        Pingu01 = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Accede al sprite renderer
        rb = GetComponent<Rigidbody2D>(); // Accede a Rigidbody2D
    }

    void Update()
    {
        if (Pingu01 == null) return;

        float distancia = Vector2.Distance(transform.position, Pingu01.transform.position);
        float velocidadFinal = velocidadEnemigoFast * Time.deltaTime;

        // Control animacion de distancia al personaje
        anim.SetFloat("distanceToPlayer", distancia);

        // Volteo de la Orca basado en la posición del pingüino
        if (Pingu01.transform.position.x > transform.position.x)
        {
            // El pingu está a la derecha de la Orca
            spriteRenderer.flipX = true;
        }
        else
        {
            // El pingu está a la izquierda de la Orca
            spriteRenderer.flipX = false;
        }

        
        Vector2 targetPosition = Vector2.zero;

        if (distancia <= attackThreshold)
        {
            // Modo ataque
            anim.SetBool("IsAttacking", true);
            anim.SetBool("IsMoving", false);

                        targetPosition = new Vector2(Pingu01.transform.position.x, Pingu01.transform.position.y);
            Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

            
            rb.velocity = direction * velocidadEnemigoFast;
        }
        else if (distancia <= moveThreshold)
        {
            //Debug.Log
            // Se mueve hacia el jugador
            anim.SetBool("IsAttacking", false);
            anim.SetBool("IsMoving", true);

           
            targetPosition = new Vector2(Pingu01.transform.position.x, Pingu01.transform.position.y);
            Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

            
            rb.velocity = direction * velocidadEnemigoFast;
        }
        else
        {
            // Vuelve a la posición inicial
            anim.SetBool("IsAttacking", false);
            bool shouldMoveBack = Vector2.Distance(transform.position, posicionInicial) > 0.05f;
            anim.SetBool("IsMoving", shouldMoveBack);

            targetPosition = new Vector2(posicionInicial.x, posicionInicial.y);
            Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

            
            rb.velocity = direction * velocidadEnemigoFast;
        }
    }
}
