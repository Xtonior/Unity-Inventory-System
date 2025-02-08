using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GUI;
using UnityEngine;
using Utils;

public class InventoryFiller : MonoBehaviour
{
    [SerializeField] private float itemSpawnChance = 0.5f;
    [SerializeField] private GameObject inventory;
    [SerializeField] private List<InventoryItem> inventoryItems;

    private RandomWeightedSelector<InventoryItem> weightedSelector = new RandomWeightedSelector<InventoryItem>();

    public void GenerateItems()
    {
        InventorySlot[] slots = inventory.GetComponentsInChildren<InventorySlot>();

        for (int i = 0; i < inventoryItems.Count; i++)
        {
            var itm = inventoryItems[i];
            weightedSelector.AddItem(itm, itm.Weight);
        }

        foreach (var slot in slots)
        {
            if (Random.Range(0.0f, 1.0f) > itemSpawnChance) continue;
            
            var itm = weightedSelector.GetRandomItem();
            slot.SetItem(itm);
        }
    }
}
