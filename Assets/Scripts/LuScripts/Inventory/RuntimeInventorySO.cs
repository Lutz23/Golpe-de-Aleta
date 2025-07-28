using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class RuntimeInventorySO : ScriptableObject
{
    public List<ItemData> items = new List<ItemData>();

     public delegate void InventoryChanged();
    public event Action OnInventoryChanged;

    /* public bool Add(ItemData item)
     {
        if (item.isUnique && items.Contains(item)) return false;
         items.Add(item);
         OnInventoryChanged?.Invoke();
         return true;
     }*/
     
      public bool Add(ItemData item)
    {
        if (!items.Contains(item))
    {
        items.Add(item);
        OnInventoryChanged?.Invoke();
        return true; // successfully added
    }
    return false;  // Notify any listeners (UI, etc.)
    }
   
    #if UNITY_EDITOR
    private void OnValidate()
    {
        if (!Application.isPlaying)
            items.Clear();
    }
#endif

}

