using System;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class PlayerInteractions : MonoBehaviour
{
    [Header("Interaction Settings")]
    [SerializeField] private LayerMask interactableLayer;

    [SerializeField] private LevelController levelController;

    private GameObject itemInHand = null;
  
    private void OnInteract(InputValue value)
    {
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position + new Vector3(0,.35f,0), new Vector2(.65f,1), 0, interactableLayer);

        if (itemInHand == null)
        {
            ItemlessInteract(hitColliders);
        }
        else
        {
            ItemHeldInteract(hitColliders);
        }
    }

    private void ItemlessInteract(Collider2D[] hitColliders)
    {
        (IInteractable closestComponent, GameObject closestGameObject) = GetClosest<IInteractable>(hitColliders);

        if (closestComponent == null) { return; }

        if (closestGameObject.TryGetComponent<IItem>(out var item))
        {
            PickUpItem(closestGameObject);
        }
        closestComponent?.Interact();

        // Check for update in doors and lights after every interact
        levelController.UpdateLevelStatus();
    }

    private void ItemHeldInteract(Collider2D[] hitColliders)
    {
        (IItemInteractable closestComponent, GameObject closestGameObject) = GetClosest<IItemInteractable>(hitColliders);

        if (closestComponent != null)
        {
            closestComponent?.Interact(itemInHand);
        }
        else
        {
            itemInHand.GetComponent<IItem>().PutDown();
            PutDownItem(itemInHand);
        }

        // Check for update in doors and lights after every interact
        levelController.UpdateLevelStatus();
    }

    private (T closestComponent, GameObject closestGameObject) GetClosest<T>(Collider2D[] hitColliders) where T : class
    {
        T closestComponent = null;
        GameObject closestGameObject = null;
        float closestDistance = float.MaxValue;

        foreach (Collider2D col in hitColliders)
        {
            if (col.TryGetComponent(typeof(T), out var component))
            {
                T casted = component as T;
                if (casted == null) continue;

                float distance = Vector3.Distance(transform.position, col.transform.position);
                if (distance < closestDistance)
                {
                    closestComponent = casted;
                    closestGameObject = col.gameObject;
                    closestDistance = distance;
                }
            }
        }

        return (closestComponent, closestGameObject);
    }

    private void PickUpItem(GameObject item)
    {
        itemInHand = item;
        item.transform.SetParent(transform);
        item.transform.localPosition = Vector3.up * 0.25f;

        item.GetComponent<SortingGroup>().sortingOrder = 2;
    }

    private void PutDownItem(GameObject item)
    {
        itemInHand = null;
        item.transform.SetParent(transform.parent);

        item.GetComponent<SortingGroup>().sortingOrder = 0;
    }
}
