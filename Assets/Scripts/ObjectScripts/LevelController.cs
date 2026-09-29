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

    [Header("Number of Secret Ways to Complete Level")]
    [SerializeField] private int[] secretLevels;

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
        if (secretLevels.Length > 0 && CheckSecretCompletion() >= 0) { return; }

        bool newLeft = leftCompletion.GetComponent<ILevelCompletion>().GetStatus();
        if (newLeft != left && newLeft)
        {
            GetComponent<AudioSource>().PlayOneShot(greenDing);
        }
        left = newLeft;

        bool newRight = rightCompletion.GetComponent<ILevelCompletion>().GetStatus();
        if (newRight != right && newRight)
        {
            GetComponent<AudioSource>().PlayOneShot(greenDing);
        }
        right = newRight;

        levelComplete = left && right;

        leftLights.UpdateLights(left, right);
        rightLights.UpdateLights(left, right);
    }

    public bool IsLevelComplete()
    {
        return levelComplete;
    }

    public int CheckSecretCompletion()
    {
        int secretCompleted = -1;
        for (int i = 0; i < secretLevels.Length; i++)
        {
            bool left = leftCompletion.GetComponent<ILevelCompletion>().GetSecretStatus(i);
            bool right = rightCompletion.GetComponent<ILevelCompletion>().GetSecretStatus(i);

            if (left && right)
            {
                secretCompleted = i;
            }
        }

        if (secretCompleted >= 0)
        {
            levelComplete = true;
            leftLights.UpdateLightsColors(Color.black, Color.black);
            rightLights.UpdateLightsColors(Color.black, Color.black);

            return secretLevels[secretCompleted];
        }

        return -1;
    }
}