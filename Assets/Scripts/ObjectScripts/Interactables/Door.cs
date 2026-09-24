using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{
    [Header("Gameobject controlling level completion")]
    [SerializeField] private LevelController levelController;

    public void Interact()
    {
        if (levelController.IsLevelComplete())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}