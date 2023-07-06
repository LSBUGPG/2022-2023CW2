using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private List<Transform> npcList;

    public float interactRange;
    public Transform InteractSource;
    public LayerMask intLayer;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible= false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractSource.position, InteractSource.forward);
            if(Physics.Raycast(r, out RaycastHit hitInfo, interactRange, intLayer))
            {
                if(hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
            else
            {
                print("No collision");
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(InteractSource.position, InteractSource.forward * interactRange);
    }
}

