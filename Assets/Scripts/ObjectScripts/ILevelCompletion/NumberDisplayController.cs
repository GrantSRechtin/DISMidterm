using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class NumberDisplayController : MonoBehaviour, ILevelCompletion
{
    [SerializeField] NumberDisplay[] displays;

    public bool GetStatus()
    {
        foreach (NumberDisplay display in displays)
        {
            if (!display.IsCorrect())
            {
                return false;
            }
        }
        return true;
    }
}
