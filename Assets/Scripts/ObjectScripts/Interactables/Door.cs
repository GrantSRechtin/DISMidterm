using System;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [Header("Door's lock GameObject")]
    [SerializeField] private Lock doorLock;

    private bool isUnlocked = false;

    public void Interact()
    {
        if (GetUnlockStatus())
        {
            //change to open doors sprite and handle logic of walking through here 
        }
        return; 
    }

    public bool GetUnlockStatus()
    {
        isUnlocked = doorLock ? doorLock.GetStatus() : true;
        return isUnlocked;
    }

    void Awake(){}
    void Start(){}
    void Update(){}
    void FixedUpdate(){}
}