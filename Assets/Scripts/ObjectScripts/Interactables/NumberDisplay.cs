using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class NumberDisplay : MonoBehaviour, IInteractable
{    
    private FallAfterUse fallAfterUse;
    private TextMeshPro textMesh;

    private int currentNum;

    private void Awake()
    {
        currentNum = 0;
        textMesh = GetComponentInChildren<TextMeshPro>();
        fallAfterUse = GetComponent<FallAfterUse>();
    }

    public void Interact()
    {
        if (fallAfterUse) { fallAfterUse.Step(); }
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

    public int GetNumber()
    {
        return currentNum;
    }


}
