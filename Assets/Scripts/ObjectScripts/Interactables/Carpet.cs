using UnityEngine;

public class Carpet : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject[] hiddenGameObjects;

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
    }

    void Awake(){}
    void Update(){}
    void FixedUpdate(){}
}
