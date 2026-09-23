using System;
using UnityEngine;

public class EntranceFloorColor : MonoBehaviour
{
    [Header("Light Objects")]
    [SerializeField] private SpriteRenderer leftLight;
    [SerializeField] private SpriteRenderer rightLight;

    [Header("Door Objects")]
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;

    public void Start()
    {
        StatusUpdate();
    }

    public void StatusUpdate()
    {
        IDoor left = leftDoor.GetComponent<IDoor>();
        IDoor right = rightDoor.GetComponent<IDoor>();

        if (left.GetUnlockStatus() && right.GetUnlockStatus())
        {
            SetColor(Color.green);
        }
        else if (left.GetUnlockStatus() || right.GetUnlockStatus())
        {
            SetColor(Color.yellow);
        }
        else
        {
            SetColor(Color.red);
        }

    }

    private void SetColor(Color color)
    {
        leftLight.color = color;
        rightLight.color = color;
    }
}