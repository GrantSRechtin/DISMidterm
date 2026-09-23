using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Pot : MonoBehaviour, IItemInteractable
{
    [SerializeField] private GameObject[] heldGameObjects;
    [SerializeField] private SpriteRenderer sr;

    private Collider2D potCollider;

    private void Awake()
    {
        potCollider = GetComponent<Collider2D>();
    }

    void Start()
    {
        foreach (GameObject disabledObject in heldGameObjects)
        {
            disabledObject.GetComponent<Collider2D>().enabled = false;
        }
    }

    public void Interact(GameObject item)
    {

        if (item.CompareTag("Hammer"))
        {
            potCollider.enabled = false;
            sr.enabled = false;
            foreach (GameObject disabledObject in heldGameObjects)
            {
                Collider2D collider = disabledObject.GetComponent<Collider2D>();
                if (collider)
                {
                    collider.enabled = true;
                }
            }

            item.GetComponent<Hammer>().Swing();
        }
    }

    void Update() { }
    void FixedUpdate() { }
}
