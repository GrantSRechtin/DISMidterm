using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class DoorLock : MonoBehaviour, ILevelCompletion
{
    private Lock lockScript;

    private void Awake()
    {
        lockScript = GetComponent<Lock>();
    }

    public bool GetStatus()
    {
        return lockScript.IsUnlocked();
    }
}
