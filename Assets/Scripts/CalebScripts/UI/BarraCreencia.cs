using UnityEngine;
using UnityEngine.UI;

public class BarraCreencia : MonoBehaviour
{
    public Sprite[] etapas; // 0-4 etapas
    private Image imagen;


    void Start()
    {
       
        imagen = GetComponent<Image>();
        ActualizarBarra(); // por si ya hay progreso al iniciar
    }

    public void ActualizarBarra()
    {
        int fotos = GameManager.marcadorFotos;

        if (fotos >= 0 && fotos < etapas.Length)
        {
            imagen.sprite = etapas[fotos];
        }
        else if (fotos >= etapas.Length)
        {
            imagen.sprite = etapas[etapas.Length - 1];
        }
    }
}