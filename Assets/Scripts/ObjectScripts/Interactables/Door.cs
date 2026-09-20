using System;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private bool isUnlocked = false;

    [Header("Door's lock GameObject")]
    [SerializeField] private GameObject doorLock;



    public void Interact()
    {
        Lock doorlock = doorLock.GetComponent<Lock>();
        if (doorlock.GetStatus())
        {
            isUnlocked = true;
            //change to open doors sprite and handle logic of walking through here 
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