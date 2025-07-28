using UnityEngine;

public class InventoryUI : MonoBehaviour
{
     [SerializeField] //añado 25/05
        private InventorySlotUI itemPrefab; 

        [SerializeField] //añado 25/05
        private RectTransform contentPanel;

        [SerializeField] //añado 25/05
        private ItemDetailPanel itemDescription;

      //  [SerializeField] //añado 25/05
       // private MouseFollower mouseFollower;
    GameObject inventoryPanel; // Arrastra aquí tu InventoryPanel
    public Transform slotsParent;    // Arrastra aquí tu SlotsContainer
    public GameObject slotPrefab;    // Arrastra aquí tu InventorySlot_Template

    private InventorySlotUI[] slots;

 private static InventoryUI instance; //añado 26/05

   /*  void Awake() //añado 26/05
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // ya existe uno, destruye el nuevo
        }
    }
 */
    void Start()
    {
        // Suscribirse al evento de cambio del inventario
        InventoryManager.instance.onInventoryChangedCallback += UpdateUI;

        // Inicializar los slots (crear tantos como inventorySize)
        slots = new InventorySlotUI[InventoryManager.instance.inventorySize];
        for (int i = 0; i < InventoryManager.instance.inventorySize; i++)
        {
            GameObject slotGO = Instantiate(slotPrefab, slotsParent);
            slots[i] = slotGO.GetComponent<InventorySlotUI>();
            slots[i].ClearSlot(); // Asegúrate de que empiecen vacíos
        }
        inventoryPanel = this.gameObject; // Asignar el panel del inventario

        UpdateUI(); // Actualizar la UI inicialmente

        
    }


    void UpdateUI()
    {
        Debug.Log("Actualizando UI del inventario...");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < InventoryManager.instance.items.Count)
            {
                slots[i].DisplayItem(InventoryManager.instance.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    // Es buena práctica desuscribirse cuando el objeto se destruye
    void OnDestroy()
    {
        if (InventoryManager.instance != null)
        {
            InventoryManager.instance.onInventoryChangedCallback -= UpdateUI;
        }
    }

    void OnDisable()
{
    if (ItemDetailPanel.instance != null)
    {
        ItemDetailPanel.instance.Hide();
    }
}

}