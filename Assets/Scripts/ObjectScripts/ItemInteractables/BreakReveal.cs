using UnityEngine;

public class BreakReveal : MonoBehaviour, IItemInteractable
{
    [Header("Objects inside the pot")]
    [SerializeField] private GameObject[] heldGameObjects;
    [Header("Object audio")]
    [SerializeField] private AudioClip potBreak;

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
            GetComponent<AudioSource>().PlayOneShot(potBreak);
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
