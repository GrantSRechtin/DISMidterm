using System;
using UnityEngine;

public class EntranceFloorColor : MonoBehaviour
{
    [Header("Light Objects")]
    [SerializeField] private SpriteRenderer leftLight;
    [SerializeField] private SpriteRenderer rightLight;

    private void Start()
    {
        SetColor(Color.red);
    }

    public void StatusUpdate(int playersReady)
    {
        if (playersReady == 2)
        {
            SetColor(Color.green);
        }
        else if (playersReady == 1)
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