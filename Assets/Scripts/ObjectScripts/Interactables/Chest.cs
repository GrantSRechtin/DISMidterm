using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private bool isUnlocked = false;

    [Header("Chest's lock GameObject")]
    [SerializeField] private GameObject chestLock;

    [Header("Open chest sprite")]
    [SerializeField] private Sprite openChestSprite;

    public void Interact()
    {
        if (chestLock == null)
        {
            Debug.Log("chest lock not assigned");
            return;
           
        }

        Lock chestlock = chestLock.GetComponent<Lock>();
        if (chestlock.GetStatus())
        {
            isUnlocked = true;
            Debug.Log("chest unlocked");

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null && openChestSprite != null)
            {
                spriteRenderer.sprite = openChestSprite;
                Debug.Log("chest open");
            }
           

            // handle logic of getting item inside here
        }
    }

    public bool GetUnlockStatus()
    {
        return isUnlocked;
    }

    void Awake() { }
    void Start() { }
    void Update() { }
    void FixedUpdate() { }
}
