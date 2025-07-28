using UnityEngine;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    public static UI_Inventory Instance { get; private set; }

    [Header("Runtime data")]
    [SerializeField] private RuntimeInventorySO inventory;

    [Header("References")]
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject backpackIcon;
    [SerializeField] private GameObject itemUIPrefab;
    [SerializeField] private Transform inventoryContentPanel;

    [Header("Item Description")]
    [SerializeField] private TMP_Text itemTitle;
    [SerializeField] private TMP_Text itemDescription;

    [Header("Config")]
    [SerializeField] private KeyCode toggleKey = KeyCode.Q;

    private bool hasBackpack = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        panel.SetActive(false);
        backpackIcon.SetActive(false);
    }

    private void OnEnable() => inventory.OnInventoryChanged += Refresh;
    private void OnDisable() => inventory.OnInventoryChanged -= Refresh;

    void Update()
    {
        if (hasBackpack && Input.GetKeyDown(toggleKey))
        {
            panel.SetActive(!panel.activeSelf);
        }
    }

    public void ShowBackpackIcon()
    {
        if (backpackIcon == null)
        {
            Debug.LogError("BackpackIcon reference is NULL!");
            return;
        }

        hasBackpack = true;
        backpackIcon.SetActive(true);
    }

    private void Refresh()
    {
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        foreach (Transform child in inventoryContentPanel)
            Destroy(child.gameObject);

        foreach (var item in inventory.items)
        {
            GameObject itemGO = Instantiate(itemUIPrefab, inventoryContentPanel);
            UI_ItemInventory itemUI = itemGO.GetComponent<UI_ItemInventory>();
            itemUI.Setup(item); 
        }
    }

    public void ShowItemDetails(ItemData item)
    {
        if (item == null) return;

        itemTitle.text = item.itemName;
        itemDescription.text = item.description;
    }
}

