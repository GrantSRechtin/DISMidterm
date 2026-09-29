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
        int secretScene = levelController.CheckSecretCompletion();
        if (secretScene >= 0)
        {
            SceneManager.LoadScene(secretScene);
        }
        else if (levelController.IsLevelComplete())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}