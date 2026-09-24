using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [Header("Chest's stored GameObjects")]
    [SerializeField] private GameObject[] hiddenGameObjects;

    [Header("Chest's lock GameObject")]
    [SerializeField] private GameObject chestLock;

    [Header("Open chest sprite")]
    [SerializeField] private Sprite openChestSprite;

    [Header("Chest left=true, Chest right=false")]
    [SerializeField] private bool chestOrientation;

    private int interactNum=0;

    void Start()
    {
        foreach (GameObject hiddenObject in hiddenGameObjects)
        {
            hiddenObject.GetComponent<IHidden>().Hide();
        }
    }

    public void Interact()
    {
        if (interactNum != 0)
        {
            return;
        }
        if (chestLock == null)
        {
            Debug.Log("chest lock not assigned");
            return;
           
        }

        Lock chestlock = chestLock.GetComponent<Lock>();
        if (chestlock.IsUnlocked())
        {
            Debug.Log("chest unlocked");

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null && openChestSprite != null)
            {
                spriteRenderer.sprite = openChestSprite;
                if (chestOrientation)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.4f, gameObject.transform.position.y, gameObject.transform.position.z);
                    Debug.Log("chest open");
                    
                }
                else
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.4f, gameObject.transform.position.y, gameObject.transform.position.z);
                    Debug.Log("chest open");
                }
                interactNum+=1;
                   
            }
           
            foreach (GameObject hiddenObject in hiddenGameObjects)
            {
                hiddenObject.GetComponent<IHidden>().Show();
            }
        }
    }
}
