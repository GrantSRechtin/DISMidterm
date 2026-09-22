using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private bool isUnlocked = false;

    [Header("Chest's lock GameObject")]
    [SerializeField] private GameObject chestLock;



    public void Interact()
    {
        Lock chestlock = chestLock.GetComponent<Lock>();
        if (chestlock.GetStatus())
        {
            isUnlocked = true;
            //change to open chest sprite and handle logic of getting item inside here 
        }
        return; 
    }

    public bool GetUnlockStatus()
    {
        return isUnlocked;
    }

    void Awake(){}
    void Start(){}
    void Update(){}
    void FixedUpdate(){}
}
