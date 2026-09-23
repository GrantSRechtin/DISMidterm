using System;
using TMPro;
using UnityEngine;

public class NumberDisplay : MonoBehaviour, IInteractable
{
    [SerializeField] private int correctNum = 0;

    private TextMeshPro textMesh;

    private int currentNum;

    private void Awake()
    {
        currentNum = 0;
        textMesh = GetComponentInChildren<TextMeshPro>();
    }

    public void Interact()
    {
        if (currentNum < 9)
        {
            currentNum++;
            textMesh.text = currentNum.ToString();
        }
        else
        {
            currentNum = 0;
            textMesh.text = currentNum.ToString();
        }
    }

    public bool IsCorrect()
    {
        return currentNum == correctNum;
    }
}
