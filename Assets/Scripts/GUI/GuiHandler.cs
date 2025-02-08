using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GUI
{
    public class GuiHandler : MonoBehaviour
    {
        private InventoryBase currentInventory;
        private bool isGuiActive;
        public bool IsGuiActive() => isGuiActive;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                HideInventory(currentInventory);
            }
        }

        public void ShowInventory(InventoryBase inventory)
        {
            if (isGuiActive) return;

            currentInventory = inventory;
            inventory.GetPanel().SetActive(true);
            isGuiActive = true;
        }

        public void HideInventory(InventoryBase inventory)
        {
            currentInventory = null;
            inventory.GetPanel().SetActive(false);
            isGuiActive = false;
        }
    }
}