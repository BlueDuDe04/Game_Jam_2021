using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance;
    public Camera camera;
    public Transform player;
    public Transform heldObjectPlaceHolder;
    public bool isHoldingItem;
    public GameObject hoveredItem;
    public IPickup heldItem;

    private void Start() {
        
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else 
            Instance = this; 
    }

    private void Update() {

        if (Input.GetKeyDown("e"))
        {
            if (isHoldingItem)
            {
                isHoldingItem = false;
                heldItem.OnDrop();
                return;
            }
            else if (isHoveringInteractable())
            {
                Interact();
            }
            
        }
    }

    private void Interact()
    {
        if (hoveredItem.TryGetComponent<IPickup>(out IPickup holdableItem))
            {
                isHoldingItem = true;
                heldItem = holdableItem;
                heldItem.OnPickup();
                return;
            }
                
        else if (hoveredItem.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                interactable.InteractWithObject();
                return;
            }

        return;
    }

    private bool isHoveringInteractable()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawLine(ray.origin, ray.direction * 100f, Color.red);

        if (Physics.Raycast(ray, out hit)
        && isPlayerInRange(hit))
        {
            if (hit.transform.tag == "Interactable")
            {
                hoveredItem = hit.transform.gameObject;
                return true;
            }
            return false;
        }
        hoveredItem = null;
        return false;
    }

    private bool isPlayerInRange(RaycastHit _hit)
    {
        var distanceFromObject = player.position - _hit.transform.position;

        if (distanceFromObject.magnitude <= 18.0f)
            return true;
         
        return false;
    }


}
