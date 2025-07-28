using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PageInventory : MonoBehaviour
{
    [SerializeField]
    private UI_ItemInventory itemPrefab;

    [SerializeField]
    private RectTransform contentPanel;

    List<UI_ItemInventory> listOfUIItems = new List<UI_ItemInventory>();


    //Para crear distinto numero de items en nuestro inventario
    public void InitializeInventoryUI(int inventorysize)
    {
        for (int i = 0; i < inventorysize; i++)
        {
            UI_ItemInventory uiItem =
                Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            listOfUIItems.Add(uiItem);
        }
    }

    //para esconder y mostrar el inventario a demanda
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    
}
