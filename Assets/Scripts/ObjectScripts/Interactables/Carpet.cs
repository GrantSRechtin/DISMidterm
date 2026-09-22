using UnityEngine;

public class Carpet : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject[] hiddenGameObjects;
    [SerializeField] private Sprite flippedCarpet;

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
        sr.sprite = flippedCarpet;
    }

    void Update(){}
    void FixedUpdate(){}
}
