using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private bool isUnlocked = false;

    [Header("Chest's stored GameObjects")]
    [SerializeField] private GameObject[] hiddenGameObjects;

    [Header("Chest's lock GameObject")]
    [SerializeField] private GameObject chestLock;

    [Header("Open chest sprite")]
    [SerializeField] private Sprite openChestSprite;

    void Start()
    {
        foreach (GameObject hiddenObject in hiddenGameObjects)
        {
            hiddenObject.GetComponent<IHidden>().Hide();
        }
    }

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
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.4f, gameObject.transform.position.y, gameObject.transform.position.z);
                Debug.Log("chest open");
            }
           
            foreach (GameObject hiddenObject in hiddenGameObjects)
            {
                hiddenObject.GetComponent<IHidden>().Show();
            }
        }
    }

    public bool GetUnlockStatus()
    {
        return isUnlocked;
    }

    void Awake() { }
    void Update() { }
    void FixedUpdate() { }
}
