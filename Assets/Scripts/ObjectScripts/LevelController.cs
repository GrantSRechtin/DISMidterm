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

    private bool levelComplete = false;

    private void Start()
    {
        UpdateLevelStatus();
    }

    public void UpdateLevelStatus()
    {
        bool left = leftCompletion.GetComponent<ILevelCompletion>().GetStatus();
        bool right = rightCompletion.GetComponent<ILevelCompletion>().GetStatus();

        levelComplete = left && right;

        leftLights.UpdateLights(left, right);
        rightLights.UpdateLights(left, right);
    }

    public bool IsLevelComplete()
    {
        return levelComplete;
    }
}