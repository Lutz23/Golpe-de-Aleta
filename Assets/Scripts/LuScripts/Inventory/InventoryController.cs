/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance { get; private set; }
    [SerializeField] private RuntimeInventorySO inventory;

   // public RuntimeInventorySO Data => inventory;

    public RuntimeInventorySO RuntimeInventorySO;


    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

    /*[SerializeField]

    public int inventorySize = 10;

    private void Start()
    {
        inventoryUI.InitializeInventoryUI(inventorySize);
    }
    private UI_PageInventory inventoryUI;
    } */

using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance { get; private set; }

    [SerializeField] private RuntimeInventorySO inventory;

    public RuntimeInventorySO Data => inventory;

    public List<GameObject> ListadoInventario = new List<GameObject>();



    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        if (transform.root == transform)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("[InventoryController] GameObject is not root — cannot be marked DontDestroyOnLoad");
        }
    }
}
