using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GUI
{
    public class InventoryBase : MonoBehaviour
    {
        [SerializeField] private Vector2Int inventorySize = Vector2Int.one;
        public Vector2Int GetInventorySize() => inventorySize;
    }
}
