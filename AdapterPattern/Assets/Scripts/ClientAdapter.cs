using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientAdapter : MonoBehaviour
{
    public InventoryItem item;
    private InventorySystem inventorySystem;
    private IInventorySystem inventorySystemAdapter;

    private SaveTo saveTo; // original class
    private ISaveTo saveToAdapter; // adapted class



    public List<string> data = new List<string>();


    void Start()
    {
        inventorySystem = new InventorySystem();
        inventorySystemAdapter = new InventorySystemAdaptor();

        saveTo = new SaveTo();
        saveToAdapter = new SaveToAdapter();

        data.Add("Hello");
        data.Add("World");
    }


    void OnGUI()
    {
        if (GUILayout.Button("Add item (no adaptor)"))
        {
            inventorySystem.AddItem(item);
        }
        if (GUILayout.Button("Add item (with adaptor)"))
        {
            inventorySystemAdapter.AddItem(item, SaveLocation.Both);
        }

        if (GUILayout.Button("Add item to CSV file (no adapter)"))
        {
            saveTo.SaveString(data);
            Debug.Log("saved to CSV w/ no adapter");
        }

        if (GUILayout.Button("Add item to JSON file"))
        {
            saveToAdapter.SaveString(data, SaveLocation.JSON);

            Debug.Log("saved to Json w/ adapter");
        }
    }
}
