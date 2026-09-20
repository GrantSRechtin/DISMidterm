using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SortingGroup))]

public class Key : MonoBehaviour, IInteractable, IItem, IHidden
{
    public void Interact()
    {
        GetComponent<Collider2D>().enabled = false;
    }

    public void PutDown()
    {
        GetComponent<Collider2D>().enabled = true;
    }

    public void Hide()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SortingGroup>().sortingLayerName = "Hidden";
    }

    public void Show()
    {
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SortingGroup>().sortingLayerName = "Default";
    }

    void Awake(){}
    void Start(){}
    void Update(){}
    void FixedUpdate(){}
}
