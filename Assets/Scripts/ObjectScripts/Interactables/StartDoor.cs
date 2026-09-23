using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartDoor : MonoBehaviour, IInteractable, IDoor
{
    [SerializeField] private Collider2D player;
    [SerializeField] private StartDoor otherDoor;
    [SerializeField] private EntranceFloorColor entranceFloorColor;
    [SerializeField] private LevelLights leftLights;
    [SerializeField] private LevelLights rightLights;

    private bool isUnlocked = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == player)
        {
            isUnlocked = true;
        }
        entranceFloorColor.StatusUpdate();
        leftLights.StatusUpdate();
        rightLights.StatusUpdate();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == player)
        {
            isUnlocked = false;
        }
        entranceFloorColor.StatusUpdate();
        leftLights.StatusUpdate();
        rightLights.StatusUpdate();
    }

    public void Interact()
    {
        if (isUnlocked && otherDoor.GetUnlockStatus())
        {
            SceneManager.LoadScene(1);
        }
    }

    public bool GetUnlockStatus()
    {
        return isUnlocked;
    }

    void Start(){}
    void Update(){}
    void FixedUpdate(){}
}