using System;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private bool isUnlocked=false;

    public void Interact()
    {
        
    }

    public Boolean GetUnlockStatus()
    {
        return isUnlocked;
    }

    void Awake(){}
    void Start(){}
    void Update(){}
    void FixedUpdate(){}
}