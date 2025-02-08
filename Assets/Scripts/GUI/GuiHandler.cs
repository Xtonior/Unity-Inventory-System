using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GUI
{
    public class GuiHandler : MonoBehaviour
    {
        [SerializeField] private InventoryBase playerInventory;
        [SerializeField] private InventoryGui playerInventoryGui;
        [SerializeField] private InventoryGui externalInventoryGui;

        private InventoryBase externalInventory;
        private bool isGuiActive = false;
        public bool IsGuiActive() => isGuiActive;

        void Start()
        {
            // Setup it once, because we don't retarget player inventory
            playerInventoryGui.OpenInventory(playerInventory);

            HideInventory();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                ShowPlayerInventory();
                isGuiActive = true;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                HideInventory();
            }
        }

        public void ShowInventory(InventoryBase inventory)
        {
            if (isGuiActive) return;

            // Todo revamp it later
            if (!playerInventoryGui.IsContentShown())
            {
                ShowPlayerInventory();
            }

            externalInventory = inventory;
            externalInventoryGui.OpenInventory(inventory);
            externalInventoryGui.Show();

            isGuiActive = true;
        }

        public void HideInventory()
        {
            externalInventory = null;
            externalInventoryGui.Hide();

            playerInventoryGui.Hide();

            isGuiActive = false;
        }

        private void ShowPlayerInventory()
        {
            playerInventoryGui.Show();
        }
    }
}