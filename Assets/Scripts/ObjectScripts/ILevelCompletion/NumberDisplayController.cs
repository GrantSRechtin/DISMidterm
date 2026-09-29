using JetBrains.Annotations;
using Mono.Cecil.Cil;
using Unity.VisualScripting;
using UnityEngine;

public class NumberDisplayController : MonoBehaviour, ILevelCompletion
{
    [SerializeField] NumberDisplay[] displays;
    [SerializeField] int[] standardCode;

    [SerializeField] int[] secretCode1;
    [SerializeField] int[] secretCode2;

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
        int[] code = secret == 0 ? secretCode1 : secretCode2;

        for (int i = 0; i < displays.Length; i++)
        {
            if (displays[i].GetNumber() != code[i])
            {
                return false;
            }
        }
        return true;
    }
}
