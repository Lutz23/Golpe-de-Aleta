using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public ItemData itemData; // Asigna el ScriptableObject del item aquí


    bool estoyTocandoObjeto = false;

    bool heSidoRecogido = false;

    // porque nuestro objecto es un trigger Esto estaba comentado antes
    /* void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp();
        }
    } 
 */
    // porque nuestro objecto NO es un trigger
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            estoyTocandoObjeto = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            estoyTocandoObjeto = false;
        }
    }

    void PickUp()
    {
        Debug.Log("Recogiendo: " + itemData.itemName);
        bool wasPickedUp = InventoryManager.instance.AddItem(itemData);

        if (wasPickedUp)
        {

            heSidoRecogido = true;
            //Destroy(gameObject); // Destruir el objeto del mundo si se añadió al inventario
        }
        { // Añadido 27/05
            GameManager.marcadorFotos++;
            Debug.Log("Fotos recogidas: " + GameManager.marcadorFotos);
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && estoyTocandoObjeto && !heSidoRecogido)
        {
            
            PickUp();
        }
    }


}