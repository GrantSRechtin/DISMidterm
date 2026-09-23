using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class DoorController : MonoBehaviour, ILock
{
    [SerializeField] NumberDisplay red;
    [SerializeField] NumberDisplay blue;
    [SerializeField] NumberDisplay pink;
    [SerializeField] NumberDisplay tan;

    public bool GetStatus()
    {
        return red.IsCorrect() && blue.IsCorrect() && pink.IsCorrect() && tan.IsCorrect();
    }
}
