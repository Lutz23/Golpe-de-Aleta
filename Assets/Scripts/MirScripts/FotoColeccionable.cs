using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FotoColeccionable : MonoBehaviour
{
    private bool playerInRange = false;
    //private AudioSource audioSource;
    AudioManagerScript audioManager;
   void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    //public string itemName;
      void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("He sacado una foto");
           // StartCoroutine(ReproducirYDestruir());

             Debug.Log("Destruyendo objeto ahora");
        //AudioManagerScript.Instance.SuenaClip(AudioManagerScript.Instance.s_ClickFoto);
        Destroy(gameObject, 1.2f);
        }
    
    
        // if (audioSource.clip != null)
        // {
        //     audioSource.Play();
        //     yield return new WaitForSeconds(audioSource.clip.length);
        // }
        // else
        // {
        //     Debug.LogWarning("No hay clip de audio asignado");
        //     yield return new WaitForSeconds(1.0f); // Espera por si acaso
        // }
       
    }

   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("He encontrado a pingu");
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}