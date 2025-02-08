using System.Collections;
using System.Collections.Generic;
using GUI;
using UnityEngine;

namespace Interaction
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private Transform rayOirign = null;
        [SerializeField] private float maxDistance = 10.0f;
        [SerializeField] private LayerMask includeLayers;
        [SerializeField] private GuiHandler guiHandler;

        void Update()
        {
            if (guiHandler.IsGuiActive()) return;

            RaycastHit hitInfo;

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Physics.Raycast(rayOirign.transform.position, rayOirign.forward, out hitInfo, maxDistance, includeLayers))
                {
                    var interactable = hitInfo.transform.GetComponent<IInteractable>();

                    if (interactable != null)
                    {
                        interactable.Interact();
                    }
                }
            }
        }
    }
}
