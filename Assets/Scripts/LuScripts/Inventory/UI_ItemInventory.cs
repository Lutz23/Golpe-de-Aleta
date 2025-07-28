
using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class UI_ItemInventory : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    private ItemData itemData;

    public void Setup(ItemData newItem)
    {
        itemData = newItem;
        itemIcon.sprite = itemData.icon;
    }

    /*public void OnClick()
    {
        UI_Inventory.Instance.ShowItemDetails(itemData);
    }*/
    
}
