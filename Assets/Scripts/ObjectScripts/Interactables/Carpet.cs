using UnityEngine;

public class Carpet : MonoBehaviour, IInteractable
{
    [Header("Objects hidden by the carpet")]
    [SerializeField] private GameObject[] hiddenGameObjects;
    
    [Header("Flipped carpet sprite")]
    [SerializeField] private Sprite flippedCarpet;

    [Header("Object audio")]
    [SerializeField] private AudioClip carpetSound;

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
        foreach (GameObject hiddenObject in hiddenGameObjects)
        {
            hiddenObject.GetComponent<IHidden>().Show();
        }
        GetComponent<AudioSource>().PlayOneShot(carpetSound);
        sr.sprite = flippedCarpet;

        GetComponent<Collider2D>().enabled = false;
    }
}
