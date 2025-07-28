using UnityEngine;
using UnityEngine.UI;
using TMPro; // Optional if using TextMeshPro

public class ItemDetailPanel : MonoBehaviour
{
    public static ItemDetailPanel instance;

    public Image itemIcon;
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemDescriptionText;

    

    void Awake()
    {
        instance = this;
        gameObject.SetActive(false); // Hide by default
    }

    public void ShowItemDetails(ItemData item) //Supuestamente debería de mostrar los detalles del item, pero no
    {
        Debug.Log("Setting item details: " + item.itemName);

        if (item != null)
        {
            itemIcon.sprite = item.icon;
            itemNameText.text = item.itemName;
            itemDescriptionText.text = item.description;
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false); // Hide if no item añadido ahora
        }
    }

    public void Clear() //añadido ahora
    {
         itemIcon.sprite = null;
            itemNameText.text = "";
            itemDescriptionText.text =  "";
            gameObject.SetActive(false);
        
    } 
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
