using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GUI
{
    public class InventorySlot : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Image image;
        [Header("Settings")]
        [SerializeField] private Vector2Int size;
        [SerializeField] private InventoryItem item;

        private InventoryBase inventoryBase;

        public bool IsOccupied => item != null;

        public Sprite GetSprite() => item.Icon;

        void Start()
        {
            image = GetComponent<Image>();
            inventoryBase = transform.parent.GetComponent<InventoryBase>();
        }

        void Update()
        {
            if (!item) return;

            SetIcon(GetSprite());
        }

        public InventoryItem GetItem() => this.item;
        public void SetItem(InventoryItem item) 
        {
            if (item)
            {
                SetIcon(item.Icon);
            }
            else
            {
                SetIcon(null);
            }

            this.item = item;
        }

        private void SetIcon(Sprite sprite)
        {
            image.sprite = sprite;
        }
    }
}