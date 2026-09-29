using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Lock : MonoBehaviour, IItemInteractable
{
    [Header("Lock color string (must match key string)")]
    [SerializeField] private string color;
    
    [Header("Object audio")]
    [SerializeField] private AudioClip unlock;

    private bool unlocked = false; 
    private SpriteRenderer[] spriteRenderers;
    private Collider2D[] colliders;

    private void Awake()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        colliders = GetComponentsInChildren<Collider2D>();
    }

    public void Interact(GameObject item)
    {
        if (item.GetComponent<Key>() != null)
        {
            Key key = item.GetComponent<Key>();
            if (key.GetColor() == color)
            {
                GetComponent<AudioSource>().PlayOneShot(unlock);
                unlocked = true;
                Destroy(item);

                // Disable Lock
                Disable();
            }
        }
    }

    public bool IsUnlocked()
    {
        return unlocked;
    }

    private void Disable()
    {
        foreach (Collider2D collider in colliders)
        {
            collider.enabled = false;
        }
        foreach (SpriteRenderer sr in spriteRenderers)
        {
            sr.enabled = false;
        }
    }
}
