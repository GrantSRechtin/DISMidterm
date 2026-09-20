using UnityEngine;

public class Key : MonoBehaviour, IInteractable, IItem
{
    public void Interact()
    {
        GetComponent<Collider2D>().enabled = false;
    }

    public void PutDown()
    {
        GetComponent<Collider2D>().enabled = true;
    }

    void Awake(){}
    void Start(){}
    void Update(){}
    void FixedUpdate(){}
}
