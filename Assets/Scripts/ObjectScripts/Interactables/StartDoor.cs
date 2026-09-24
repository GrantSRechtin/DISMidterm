using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartDoor : MonoBehaviour, IInteractable, ILevelCompletion
{
    [SerializeField] private Collider2D mainPlayer;
    [SerializeField] private Collider2D otherPlayer;
    [SerializeField] private EntranceFloorColor entranceFloorColor;
    
    private LevelController levelController;

    private int playersReady = 0;
    private bool mainPlayerReady = false;
    private bool used = false;

    private void Awake()
    {
        levelController = FindFirstObjectByType<LevelController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (used) { return; }
        if (collision == mainPlayer)
        {
            playersReady++;
            mainPlayerReady = true;
        }
        if (collision == otherPlayer)
        {
            playersReady++;
        }
        entranceFloorColor.StatusUpdate(playersReady);
        levelController.UpdateLevelStatus();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (used) { return; }
        if (collision == mainPlayer)
        {
            playersReady--;
            mainPlayerReady = false;
        }
        if (collision == otherPlayer)
        {
            playersReady--;
        }
        entranceFloorColor.StatusUpdate(playersReady);
        levelController.UpdateLevelStatus();
    }

    public void Interact()
    {
        if (levelController.IsLevelComplete())
        {
            SceneManager.LoadScene(1);
            used = true;
        }
    }

    public bool GetStatus()
    {
        return mainPlayerReady;
    }
}