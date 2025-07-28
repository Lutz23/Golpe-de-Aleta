using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BackpackPickup : MonoBehaviour
{
    //[SerializeField] private ItemData       backpackItem;
    //[SerializeField] private RuntimeInventorySO inventory;
    [SerializeField] private KeyCode pickupKey = KeyCode.E;

    public GameObject BackpackIcon;
    private bool playerInRange;

    private void Start() //añadido nuevo
    {

        BackpackIcon.SetActive(false);
        Debug.Log(BackpackIcon);
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) playerInRange = true;

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player")) playerInRange = false;
    }

    
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // if (inventory.Add(backpackItem))          // returns true first time
            {
                // UI_Inventory.Instance.ShowBackpackIcon();
                //gameObject.SetActive(false);          // hide world sprite
                //BackpackIcon.SetActive(true);    // Show the UI icon añadido ahora
                // gameObject.SetActive(false);     // Hide the world backpack añadido ahora
                
                if (BackpackIcon != null) //enseña el icon del backpack una vez recogido
                    BackpackIcon.SetActive(true); 

                gameObject.SetActive(false);  

                InventoryManager.instance.EnableInventory(); //habilita el inventario al recoger el backpack
            }
        }
    }

}
