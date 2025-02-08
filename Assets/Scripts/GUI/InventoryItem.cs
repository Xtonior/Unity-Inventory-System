using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GUI
{
    [CreateAssetMenu(fileName = "Item", menuName = "Items/Item")]
    public class InventoryItem : ScriptableObject
    {
        [Header("Settings")]
        public string ItemName;
        public Sprite Icon;
        public Vector2Int Size;
        [Header("Parameters")]
        public float Weight = 50.0f;
    }
}
