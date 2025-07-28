using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEnemy : MonoBehaviour

{
    Vector3 posicionInicial;

    GameObject Pingu01;

    public float velocidadEnemigo = 5.0f;

    //AudioSource _audioSource;
    public int vidaEnemigo = 2;

    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position;
        Pingu01 = GameObject.FindGameObjectWithTag("Player");
       // _audioSource = this.GetComponent<AudioSource>();
       spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(transform.position, Pingu01.transform.position);
        float velocidadFinal = velocidadEnemigo * Time.deltaTime;

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

        //Si la distancia entre el enemigo y el personaje es menor que el valor, el enemigo sigue al personaje
        if (distancia <= 5.1f){
            transform.position = Vector3.MoveTowards(transform.position, Pingu01.transform.position, velocidadFinal);

            /*if(_audioSource.isPlaying == false){
                _audioSource.Play();*/

            }

        //Si la distancia entre el enemigo y el personaje es mayor que el valor, el enemigo vuelve a la posicion inicial
            else{
            transform.position = Vector3.MoveTowards(transform.position, posicionInicial, velocidadFinal);
            //if((transform.position == posicionInicial) && _audioSource.isPlaying == true){
               // _audioSource.Stop();
            }
             if(vidaEnemigo <= 0){
            Destroy(this.gameObject);
        }
        }
    }

       
    ///}

