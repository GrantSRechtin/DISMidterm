using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{
    private LevelController levelController;

    private void Awake()
    {
        levelController = FindFirstObjectByType<LevelController>();
    }

    public void Interact()
    {
        if (levelController.IsLevelComplete())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}