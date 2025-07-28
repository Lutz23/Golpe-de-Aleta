 using UnityEngine;
using UnityEngine.UI; // Necesario para Image y Button
// using TMPro; // Descomenta si usas TextMeshPro para la cantidad

public class InventorySlotUI : MonoBehaviour  //IPointerClickHandler IPointer... lo he añadido yo
{

    public Image iconImage;
    // public TextMeshProUGUI quantityText; // Descomenta si usas TextMeshPro

    private ItemData currentItem;

    public void DisplayItem(ItemData newItem)
    {
        currentItem = newItem;

        if (newItem != null && newItem.icon != null)
        {
            iconImage.sprite = newItem.icon;
            iconImage.enabled = true;
            currentItem = newItem; // lo he añadido yo
            // quantityText.text = "1"; // O la cantidad real si es apilable
            // quantityText.enabled = true;
        }
        else
        {
            ClearSlot();
        }
    }


    public void ClearSlot()
    {
        currentItem = null;
        iconImage.sprite = null;
        iconImage.enabled = false;
        // quantityText.text = "";
        // quantityText.enabled = false;
    }



    // Opcional: Método para usar el item o mostrar más info al hacer clic
    public void OnSlotClicked()
    {
        /*  if (currentItem != null) //esto funciona pero pruebo otra cosa
         {
             ItemDetailPanel detailUI = InventoryManager.instance.itemDetailPanel.GetComponent<ItemDetailPanel>();  //Supuestamente debería de mostrar los detalles del item, pero no
             if (detailUI != null) */
        if (InventoryManager.instance.itemDetailPanel != null) //pruebo esto
        {
            var detailPanelScript = InventoryManager.instance.itemDetailPanel.GetComponent<ItemDetailPanel>();
            if (detailPanelScript != null)

            {
                detailPanelScript.ShowItemDetails(currentItem);
            }
            else {

                // ItemDetailPanel.instance.ShowItemDetails(currentItem); // lo he añadido yo
                Debug.LogError("ItemDetailPanel component not found on itemDetailPanel GameObject!");
                // Aquí podrías implementar la lógica de usar el item,
                // equiparlo, o mostrar una ventana de descripción.
                // Por ejemplo: InventoryManager.instance.UseItem(currentItem);
            }
        }
    }

    public void OnClick()
    {
        InventoryManager.instance.itemDetailPanel.GetComponent<ItemDetailPanel>().ShowItemDetails(currentItem);
        Debug.Log("CLICKED! Showing item: " + currentItem.itemName);

    }
    
} /*

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlotUI : MonoBehaviour, IPointerClickHandler
{
    public Image icon;
    private ItemData currentItem;

    public void DisplayItem(ItemData item)
    {
        icon.sprite = item.icon;
        icon.enabled = true;
        currentItem = item;
    }

    public void ClearSlot()
    {
        icon.sprite = null;
        icon.enabled = false;
        currentItem = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (currentItem != null)
        {
            ItemDetailPanel.instance.ShowItemDetails(currentItem);
        }
    }
} */
