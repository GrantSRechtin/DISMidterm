using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    
    [SerializeField] private bool isUnlocked=false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Boolean GetUnlockStatus()
    {
        return isUnlocked;
    }
}
