//Disparo
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Video;

public class ArmaLu : MonoBehaviour
{

    public GameObject bala;
    AudioManagerScript audioManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Si presiono E el arma se activa y se dispara la bala
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(bala, this.transform.position, Quaternion.identity);
            AudioManagerScript.Instance.SuenaClip(AudioManagerScript.Instance.s_SonidoBalaBuceo);

        }
    }
}


//Ahora mismo, el arma se inicia y dispara dos balas porque hay dos gameobject con el script asignado
