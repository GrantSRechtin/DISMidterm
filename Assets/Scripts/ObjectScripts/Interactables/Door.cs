using System;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private bool isUnlocked=false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Interact()
    {
        
    }

    public Boolean GetUnlockStatus()
    {
        return isUnlocked;
    }
}