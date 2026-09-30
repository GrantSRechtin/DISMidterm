using UnityEngine;

public class Safe : MonoBehaviour, IInteractable
{
    [Header("Item(s) inside of safe")]
    [SerializeField] private GameObject[] hiddenGameObjects;
    
    [Header("Open safe sprite")]
    [SerializeField] private Sprite openSafe;

    [Header("Safe lock GameObject")]
    [SerializeField] private GameObject safeLock;
    [Header("Safe Opening Sound")]
    [SerializeField] private AudioClip safeOpen;

    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        foreach (GameObject hiddenObject in hiddenGameObjects)
        {
            hiddenObject.GetComponent<IHidden>().Hide();
        }
    }

    public void Interact()
    {
        Debug.Log("safe interacted with");
        if (safeLock == null)
        {
            Debug.Log("safe lock not assigned");
            return;
           
        }

        Lock safelock = safeLock.GetComponent<Lock>();
        if (safelock.IsUnlocked())
        {
            Debug.Log("safe unlocked");
            foreach (GameObject hiddenObject in hiddenGameObjects)
            {
                hiddenObject.GetComponent<IHidden>().Show();
            }
            GetComponent<AudioSource>().PlayOneShot(safeOpen);
            sr.sprite = openSafe;

            GetComponent<Collider2D>().enabled = false;
        }
    }
}
