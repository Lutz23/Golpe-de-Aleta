using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario_Fotos : MonoBehaviour
{
    // Start is called before the first frame update{
    public List<string> items = new List<string>();

    public void AddItem(string itemName)
    {
        items.Add(itemName);
        Debug.Log(itemName + " afegit a l'inventari.");
    }
}
