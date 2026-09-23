using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable, IDoor
{
    [Header("Door's lock GameObject")]
    [SerializeField] private GameObject doorLock;
    [SerializeField] private Door otherDoor;

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
        if (!doorLock)
        {
            return true;
        }
        return doorLock.GetComponent<ILock>().GetStatus();
    }

    void Awake(){}
    void Start(){}
    void Update(){}
    void FixedUpdate(){}
}