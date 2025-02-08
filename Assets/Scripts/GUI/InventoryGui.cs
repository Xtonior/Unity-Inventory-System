using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GUI
{
    public class InventoryGui : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [Header("References")]
        [SerializeField] private GameObject panel;
        [SerializeField] private GameObject content;
        [SerializeField] private InventoryCursor cursor;
        [SerializeField] private InventorySlot inventorySlotPrefab;

        private InventoryItem selectedItem;
        private InventorySlot lastSlot;

        private InventoryBase targetInventory;
    
        public GameObject GetPanel() => panel;
        public bool IsContentShown() => content.activeSelf;

        public void OpenInventory(InventoryBase inventory)
        {
            targetInventory = inventory;
            GenerateSlots();
        }

        public void Show()
        {
            panel.SetActive(true);
            content.SetActive(true);
        }

        public void Hide()
        {
            panel.SetActive(false);
            content.SetActive(false);
        }

        public void StartDragging(InventorySlot slot)
        {
            if (!slot.IsOccupied) return;

            cursor.SetIcon(slot.GetSprite());
            lastSlot = slot;
            selectedItem = slot.GetItem();
            slot.SetItem(null);
        }

        public void StopDragging()
        {
            cursor.Clear();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            var slot = FindRaycastSlot(eventData);

            if (!slot) return;
            StartDragging(slot);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!selectedItem) return;

            StopDragging();

            var slot = FindRaycastSlot(eventData);

            if (!slot || slot.IsOccupied)
            {
                DropItemIntoSlot(lastSlot);
                return;
            }

            DropItemIntoSlot(slot);
        }

        private void DropItemIntoSlot(InventorySlot slot)
        {
            lastSlot = null;
            slot.SetItem(selectedItem);
            selectedItem = null;
        }

        private InventorySlot FindRaycastSlot(PointerEventData eventData)
        {
            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, raycastResults);

            if (raycastResults.Count > 0)
            {
                return raycastResults[0].gameObject.GetComponent<InventorySlot>();
            }

            return null;
        }

        private void GenerateSlots()
        {
            // Todo: add object pool
            if (transform.childCount > 0)
            {
                return;
            }

            for (int x = 0; x < targetInventory.GetInventorySize().x; x++)
            {
                for (int y = 0; y < targetInventory.GetInventorySize().y; y++)
                {
                    Instantiate<InventorySlot>(inventorySlotPrefab, transform);
                }
            }
        }
    }
}
