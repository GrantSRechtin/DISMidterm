using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable, IDoor
{
    [Header("Door's lock GameObject")]
    [SerializeField] private Lock doorLock;
    [SerializeField] private Door otherDoor;

    private bool isUnlocked = false;

    public void Interact()
    {
        Debug.Log("interacted");
        if (GetUnlockStatus() && otherDoor.GetUnlockStatus())
        {
            Debug.Log("next level");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
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