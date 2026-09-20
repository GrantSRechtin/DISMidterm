using JetBrains.Annotations;
using UnityEngine;

public class Lock : MonoBehaviour, IItemInteractable
{
     [Header("Lock color string (must match key string)")]
    [SerializeField] private string color;
    private bool unlocked = false; 

    [Header("Is this a final door lock?")]
    [SerializeField] private bool isDoorLock;

    [Header("Player and Co-Payer Light GameObject")]
    [SerializeField] private GameObject playerLght;
    [SerializeField] private GameObject coPLayerLight;

    public void Interact(GameObject item)
    {
        if (item.GetComponent<Key>() != null)
        {
            Key key = item.GetComponent<Key>();
            if (key.GetColor() == color)
            {
                unlocked = true;
                if (isDoorLock)
                {
                    playerLght.GetComponent<SpriteRenderer>().color = Color.green;
                    coPLayerLight.GetComponent<SpriteRenderer>().color=Color.green;
                }
            }
        }
    }

    public bool GetStatus()
    {
        return unlocked;
    }

    void Awake() { }
    void Start() { }
    void Update() { }
    void FixedUpdate() { }
}
