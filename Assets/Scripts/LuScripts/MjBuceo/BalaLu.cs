//Fuego
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;




public class BalaLu : MonoBehaviour
{
    //public float velocidadFinal = 6f;
    GameObject Pingu01;
    bool bolaDerecha = true;

    public float speedBala = 2.0f;

    float tiempoDestruccion = 0.8f;

    float queHoraEs;
    
    AudioManagerScript audioManager;

    // Start is called before the first frame update
  void Start()
    {
        Pingu01 = GameObject.Find("Pingu01");
        bolaDerecha = Pingu01.GetComponent<PenguinSwimLu>().IsFacingRight;


        queHoraEs = Time.time;
         // player.GetComponent<MovPersonaje>()
      /* if(player.GetComponent<MovPersonaje>().direccionBalaDcha == true){
        velocidad = velocidad*1;
       }

       if(player.GetComponent<MovPersonaje>().direccionBalaDcha == true){
        velocidad = velocidad*-1;
       }*/
    }

    // Update is called once per frame
    void Update()
    {
      
       if (bolaDerecha) {
         transform.Translate(speedBala * Time.deltaTime, 0, 0, Space.World);
       }else{
         transform.Translate((speedBala * Time.deltaTime)*-1, 0, 0, Space.World);
       }

       if(Time.time >= queHoraEs + tiempoDestruccion) {
        Destroy(this.gameObject);
       }
       
    }

    void OnTriggerEnter2D(Collider2D col)
  {
    if (col.gameObject.CompareTag("Enemigo"))
    {
      Destroy(col.gameObject);
      //GameManager.muertes +=1;
      Destroy(this.gameObject); 
     AudioManagerScript.Instance.SuenaClip(AudioManagerScript.Instance.s_EnemigoMuere);

    }

    }
}
