using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class NumberDisplayController : MonoBehaviour, ILevelCompletion
{
    [SerializeField] NumberDisplay[] displays;
    [SerializeField] int[] correctCode;

    public bool GetStatus()
    {
        for (int i = 0; i < displays.Length; i++)
        {
            if (displays[i].GetNumber() != correctCode[i])
            {
                return false;
            }
        }
        return true;
    }
}
