using System;
using UnityEngine;

public class LevelLights : MonoBehaviour
{
    [Header("Light Objects")]
    [SerializeField] private SpriteRenderer leftLight;
    [SerializeField] private SpriteRenderer rightLight;

    public void UpdateLights(bool left, bool right)
    {
        leftLight.color = left ? Color.green : Color.red;
        rightLight.color = right ? Color.green : Color.red;
    }
}