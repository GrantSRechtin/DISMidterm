using System;
using UnityEngine;

public class NumberDisplayController : MonoBehaviour, ILevelCompletion
{
    [SerializeField] NumberDisplay[] displays;
    [SerializeField] int[] standardCode;

    [SerializeField] ArrayInt[] secretCodes;

    public bool GetStatus()
    {
        for (int i = 0; i < displays.Length; i++)
        {
            if (displays[i].GetNumber() != standardCode[i])
            {
                return false;
            }
        }
        return true;
    }

    public bool GetSecretStatus(int secret)
    {
        for (int i = 0; i < displays.Length; i++)
        {
            if (displays[i].GetNumber() != secretCodes[secret][i])
            {
                return false;
            }
        }
        return true;
    }
}
