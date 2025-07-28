using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    //**SCRIPT NUBES, ES EL MISMO QUE EL DEL OTRO JUEGO

    GameObject player;
    GameObject caamara;
    [SerializeField] public float velocidadParallax =0.3f;
    
    private Vector3 positionInicial;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        caamara = GameObject.FindWithTag("MainCamera");
        positionInicial= transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            positionInicial.x + (caamara.transform.position.x * velocidadParallax),
            positionInicial.y,
            0);

    }

}
