using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartDoor : MonoBehaviour, IInteractable, ILevelCompletion
{
    [SerializeField] private Collider2D player1;
    [SerializeField] private Collider2D player2;
    [SerializeField] private EntranceFloorColor entranceFloorColor;
    [SerializeField] private LevelController levelController;

    private int playersReady = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == player1 || collision == player2)
        {
            playersReady++;
        }
        entranceFloorColor.StatusUpdate(playersReady);
        levelController.UpdateLevelStatus();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == player1 || collision == player2)
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
        }
    }

    public bool GetStatus()
    {
        return playersReady == 2;
    }
}