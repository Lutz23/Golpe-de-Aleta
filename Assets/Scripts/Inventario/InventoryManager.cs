using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    private bool inventoryEnabled = false;
    // Luego asignas el panel en el inspector

    public static InventoryManager instance; // Singleton
    public List<ItemData> items = new List<ItemData>(); //listado
    public int inventorySize = 20; // Tamaño máximo del inventario por si quieres que sea dinámico

    public GameObject itemDetailPanel;
    public delegate void OnInventoryChanged(); // Delegado para eventos de cambio en el inventario
    public OnInventoryChanged onInventoryChangedCallback;

    GameObject inventoryPanel;


    void Awake()
    {
        // Configuración del Singleton
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        inventoryPanel = GameObject.Find("InventarioPanel"); // Asegúrate de que el nombre coincida
        inventoryPanel.SetActive(false); // Empezar con el inventario cerrado

        if (itemDetailPanel != null) // 
            itemDetailPanel.SetActive(false); // Empezar con el panel de detalles cerrado


    }




    /*      void Update()
{  
     // Abrir/Cerrar inventario con una tecla (ej. 'I')
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (inventoryPanel.activeSelf)
                {
                    Time.timeScale = 1; // Reanudar el juego
                }
                else
                {
                    Time.timeScale = 0; // Pausar el juego
                }

                inventoryPanel.SetActive(!inventoryPanel.activeSelf);

                 if (itemDetailPanel != null) // Mostrar/ocultar el panel de detalles junto con el inventario lo he añadido ahora
            {
                itemDetailPanel.SetActive(!isActive);
            } 

            } */
    void Update()
    {
        if (!inventoryEnabled) return;
        if (Input.GetKeyDown(KeyCode.Q)) // Añadido despues del anterior
        {
            bool isActive = inventoryPanel.activeSelf; // Define isActive antes de usarlo

            Time.timeScale = isActive ? 1 : 0;
            /*  if (isActive)
             {
                 Time.timeScale = 1; // Reanudar el juego
             }
             else
             {
                 Time.timeScale = 0; // Pausar el juego
             } */

            //Si el panel está activo, lo desactiva; y si esta inactivo, lo activa
            inventoryPanel.SetActive(!isActive); //se pregunta el estado del panel

            if (itemDetailPanel != null)
            {
                // lo muestra cuando el inventario está activo y lo esconde cuando está inactivo
                itemDetailPanel.SetActive(!isActive); //hace lo opuesto a como estaba antes
            }
        }
    }

    public void EnableInventory() //Da acceso al inventario
    {
        inventoryEnabled = true;
        Debug.Log("Inventario habilitado.");
    }





    public bool AddItem(ItemData item)
    {
        if (items.Count >= inventorySize)
        {
            Debug.Log("Inventario lleno.");
            return false; // No se pudo añadir el item
        }

        items.Add(item);

        // Notificar a los suscriptores que el inventario ha cambiado
        if (onInventoryChangedCallback != null)
        {
            onInventoryChangedCallback.Invoke();
        }
        Debug.Log("Añadido: " + item.itemName);
        return true; // Item añadido con éxito
    }

    public void RemoveItem(ItemData item)
    {
        if (items.Remove(item))
        {
            // Notificar a los suscriptores que el inventario ha cambiado
            if (onInventoryChangedCallback != null)
            {
                onInventoryChangedCallback.Invoke();
            }
            Debug.Log("Eliminado: " + item.itemName);
        }
    }
}
