using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPickup : MonoBehaviour


{
    private bool playerInRange = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            //RuntimeInventorySO.Instance.Add(itemData);
            //UI_Inventory.Instance.UpdateInventoryUI();

            Pickup();
            Debug.Log($"Added {gameObject} to inventory, but kept in world.");
        }

    }


    void Pickup()
    {
        if (!InventoryController.Instance.ListadoInventario.Contains(gameObject))
        {
            InventoryController.Instance.ListadoInventario.Add(gameObject);
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

}
