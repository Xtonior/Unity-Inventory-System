using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GUI
{
    public class InventoryBase : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [Header("Settigns")]
        [SerializeField] private Vector2Int inventorySize = Vector2Int.one;

        [Header("References")]
        [SerializeField] private GameObject panel;
        [SerializeField] private InventoryCursor cursor;
        [SerializeField] private InventorySlot inventorySlotPrefab;
        [SerializeField] private InventoryFiller inventoryFiller;

        private InventoryItem selectedItem;
        private InventorySlot lastSlot;

        void Start()
        {
            GenerateSlots();
            inventoryFiller.GenerateItems();
        }

        public GameObject GetPanel() => panel;

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
            for (int x = 0; x < inventorySize.x; x++)
            {
                for (int y = 0; y < inventorySize.y; y++)
                {
                    Instantiate<InventorySlot>(inventorySlotPrefab, transform);
                }
            }
        }
    }
}
