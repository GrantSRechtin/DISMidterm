using System.Collections;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [Header("Chest's stored GameObjects")]
    [SerializeField] private GameObject[] hiddenGameObjects;

    [Header("Chest's lock GameObject")]
    [SerializeField] private GameObject chestLock;

    [Header("Open chest sprite")]
    [SerializeField] private Sprite openChestSprite;

    [Header("Chest placement. Chest left=true, Chest right=false")]
    [SerializeField] private bool chestOrientation;
    
    [Header("Delay on use before chest open")]
    [SerializeField]private float waitTime;

    [Header("Object audio")]
    [SerializeField]private AudioClip chestOpen;

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
            GetComponent<AudioSource>().PlayOneShot(chestOpen);
            interactNum+=1;

            StartCoroutine(OpenDelay());
        }
    }

    private void Open()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null && openChestSprite != null)
        {
            spriteRenderer.sprite = openChestSprite;
            if (chestOrientation)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.4f, gameObject.transform.position.y, gameObject.transform.position.z);
                
            }
            else
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.4f, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            interactNum+=1;
        }
        
        foreach (GameObject hiddenObject in hiddenGameObjects)
        {
            hiddenObject.GetComponent<IHidden>().Show();
        }
    }

    IEnumerator OpenDelay()
    {
        yield return new WaitForSeconds(waitTime);
        Open();
    }
}
