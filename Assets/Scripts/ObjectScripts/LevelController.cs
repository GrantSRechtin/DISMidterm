using System;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [Header("Status Lights")]
    [SerializeField] private LevelLights leftLights;
    [SerializeField] private LevelLights rightLights;

    [Header("Level Completion Objects")]
    [SerializeField] private GameObject leftCompletion;
    [SerializeField] private GameObject rightCompletion;

    [Header("Object audio")]
    [SerializeField] private AudioClip greenDing;

    private bool levelComplete = false;

    private void Start()
    {
        UpdateLevelStatus();
    }

    private bool left;
    private bool right;

    public void UpdateLevelStatus()
    {
        bool newLeft = leftCompletion.GetComponent<ILevelCompletion>().GetStatus();
        if (newLeft != left && newLeft)
        {
            GetComponent<AudioSource>().PlayOneShot(greenDing);
            left = newLeft;
        }
        bool newRight = rightCompletion.GetComponent<ILevelCompletion>().GetStatus();
        if (newRight != right && newRight)
        {
            GetComponent<AudioSource>().PlayOneShot(greenDing);
            right = newRight;
        }

        levelComplete = left && right;

        leftLights.UpdateLights(left, right);
        rightLights.UpdateLights(left, right);
    }

    public bool IsLevelComplete()
    {
        return levelComplete;
    }
}