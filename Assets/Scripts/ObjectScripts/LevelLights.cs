using System;
using UnityEngine;

public class LevelLights : MonoBehaviour
{
    [Header("Light Objects")]
    [SerializeField] private SpriteRenderer leftLight;
    [SerializeField] private SpriteRenderer rightLight;

    [Header("Door Objects")]
    [SerializeField] private Door leftDoor;
    [SerializeField] private Door rightDoor;

    public void Start()
    {
        Pass();
    }

    public void Pass()
    {
        leftLight.color = leftDoor.GetUnlockStatus() ? Color.green : Color.red;
        rightLight.color = rightDoor.GetUnlockStatus() ? Color.green : Color.red;
    }
}