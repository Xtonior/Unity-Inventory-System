using System;
using System.Collections;
using System.Collections.Generic;
using GUI;
using Interaction;
using UnityEngine;

public class Container : MonoBehaviour, IInteractable
{
    [SerializeField] private InventoryBase inventory;
    [SerializeField] private GuiHandler gui;

    public event Action OnContainerOpen;

    public void Interact()
    {
        gui.ShowInventory(inventory);
        OnContainerOpen?.Invoke();
    }
}
