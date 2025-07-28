using Unity.VisualScripting;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public float velocidad = 5f;
    private bool jugadorEncima = false;
    public bool puedeMoverse = true;

    public GameObject cartelInteractuar;
   


    private void Start(){
        cartelInteractuar = GameObject.Find("CartelInteractuar");
    }


    private void Update()
    {       
       if (puedeMoverse && jugadorEncima && cartelInteractuar.GetComponent<Dialogue>().yaHableconPingu && GameManager.marcadorMadera >= 20)
{
    transform.position += Vector3.right * velocidad * Time.deltaTime;
}
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
       
           if (col.gameObject.name == "Player")
        {
            // Solo subir si ya habló y tiene al menos 3 maderas
            if (cartelInteractuar.GetComponent<Dialogue>().yaHableconPingu)
            {
                if (GameManager.marcadorMadera >= 3)
                {
                    Debug.Log("tengo mas de 3 maderas y se mueve la plataforma");
                    col.transform.SetParent(transform);
                    jugadorEncima = true;
                }
                else
                {
                    Debug.Log("Te faltan maderas (mínimo 3) para usar la plataforma");
                }
            }
            else
            {
                Debug.Log("Habla con el personaje antes de usar la plataforma");
            }
        }
    }
    

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Debug.Log("Jugador se bajó de la plataforma y no esta emparentado con la balsa");
            col.transform.SetParent(null);
            jugadorEncima = false;
        }
    }
}
