using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goals : MonoBehaviour
{
     //**RECOGE MADERAS Y LO MUESTRA EN EL MARCADOR
    public int valor = 1;
    GameObject audioManajerObj;
    AudioManagerScript audioManager;

    
    // Start is called before the first frame update
    void Start()
    {
        audioManajerObj = GameObject.Find("AudioManajerObj");
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
         if(col.CompareTag("Player")){

            GameManager.marcadorMadera = GameManager.marcadorMadera+valor;

            Debug.Log("maderas:"+ valor);
            this.GetComponent<Animator>().SetBool("destruirMadera", true);

            AudioManagerScript.Instance.SuenaClip(AudioManagerScript.Instance.s_RecogerMadera);

            Destroy(this.gameObject, 1.0f);

        }

    }
    
    } 


