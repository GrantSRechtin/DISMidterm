using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Pot : MonoBehaviour, IItemInteractable
{
    [Header("Objects inside the pot")]
    [SerializeField] private GameObject[] heldGameObjects;
    [Header("Object audio")]
    [SerializeField] private AudioSource potBreak;

    [SerializeField] private SpriteRenderer[] srs;

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
            foreach (SpriteRenderer sr in srs)
            {
                sr.enabled = false;
            }
            potBreak.Play();
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
}
