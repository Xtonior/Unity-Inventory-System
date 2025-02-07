using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GUI
{
    public class InventoryViewBase : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private Vector2Int size;

        private List<InventorySlot> inventorySlots;

        void Start()
        {
            Generate(size);
        }

        void Update()
        {
            // Todo make it rerener on events
            
        }

        public void Generate(Vector2Int size)
        {

        }
    }
}