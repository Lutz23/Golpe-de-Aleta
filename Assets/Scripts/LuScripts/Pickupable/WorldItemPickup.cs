using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WorldItemPickup : MonoBehaviour
{
    public ItemData itemData;
    private bool playerInRange = false;

    public string miDescripcion = "";


    // Update is called once per frame
    void Update()
     {
         if (playerInRange && Input.GetKeyDown(KeyCode.E))
         {
            //RuntimeInventorySO.Instance.Add(itemData);
            //UI_Inventory.Instance.UpdateInventoryUI();

            Pickup();
             Debug.Log($"Added {itemData.name} to inventory, but kept in world.");
         }
     }

    void Pickup()
    {
        if (InventoryController.Instance.Data.Add(itemData))
        {
            //gameObject.SetActive(false);//Esto para esconder el objeto (opcional)
        }
        else
        {
            Debug.Log("Item in inventory");
        }
     }

     private void OnTriggerEnter2D(Collider2D col)
     {
         if (col.CompareTag("Player"))
             playerInRange = true;
     }
     private void OnTriggerExit2D(Collider2D col)
     {
         if (col.CompareTag("Player"))
             playerInRange = false;
     }

   

    /*private InventoryController inventoryController;
    
    void Start()
    {
        inventoryController = FindObjectOfType<InventoryController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                //Add item inventory
            }
        }
    }*/
}

