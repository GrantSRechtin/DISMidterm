using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{
    [Header("Door opening sprites")]
    [SerializeField] private Sprite[] doorSprites;

    [Header("Object audio")]
    [SerializeField]private AudioClip chestOpen;

    private LevelController levelController;
    private bool open = false;

    private void Awake()
    {
        levelController = FindFirstObjectByType<LevelController>();
    }

    public void Interact()
    {
        if (!open && levelController.IsLevelComplete())
        {
            open = true;
            StartCoroutine(DoorAnimation());
        }
        else if (levelController.IsLevelComplete())
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

    IEnumerator DoorAnimation()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        GetComponent<AudioSource>().PlayOneShot(chestOpen);

        yield return new WaitForSeconds(0.2f);

        foreach (Sprite doorSprite in doorSprites)
        {
            sr.sprite = doorSprite;
            yield return new WaitForSeconds(0.12f);
        }
    }
}