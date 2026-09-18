using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements.Experimental;

public class PlayerInteractions : MonoBehaviour
{
    [Header("Interaction Settings")]
    [SerializeField] private float interactionRadius = 0.5f;
    [SerializeField] private LayerMask interactableLayer;

    private GameObject itemInHand;
  
    
    private void OnInteract(InputValue value)
    {
        if (itemInHand)
        {
            return;
        }
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactionRadius, interactableLayer);
        
        IInteractable closestInteractable = null;
        float closestDistance = float.MaxValue;

        foreach (Collider col in hitColliders)
        {
            if (col.TryGetComponent<IInteractable>(out var interactable))
            {
                float distance = Vector3.Distance(transform.position, col.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestInteractable = interactable;
                }
            }
        }

        closestInteractable?.Interact();
    }

    


   


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
