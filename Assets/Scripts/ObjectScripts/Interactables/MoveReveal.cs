using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class MoveReveal : MonoBehaviour, IInteractable
{
    [Header("Objects disabed by the table")]
    [SerializeField] private GameObject[] disabledGameObjects;

    [Header("Shift position")]
    [SerializeField] private Vector3 shift = new(0.25f,0.5f,0);

    [Header("Movement steps")]
    [SerializeField] private float shiftSteps = 30;
    
    [Header("Object audio")]
    [SerializeField] private AudioClip moveObject;

    private bool singleUse = true;
    private bool interactOutcome = true;

    void Start()
    {
        foreach (GameObject disabledObject in disabledGameObjects)
        {
            disabledObject.GetComponent<Collider2D>().enabled = false;
        }
    }
    public void Interact()
    {
        if (singleUse) { GetComponent<Collider2D>().enabled = false; }
    
        StartCoroutine(Shift());
    }

    IEnumerator Shift()
    {

        GetComponent<AudioSource>().PlayOneShot(moveObject);
        // Shift to new position
        for (int i = 0; i < shiftSteps; i++)
        {
            transform.position += shift / shiftSteps;
            yield return new WaitForFixedUpdate();
        }

        // Enable previously obstructed interactibles
        foreach (GameObject disabledObject in disabledGameObjects)
        {
            disabledObject.GetComponent<Collider2D>().enabled = interactOutcome;
        }

        // Reverse shift direction and outcome for if not single use
        shift *= -1;
        interactOutcome = !interactOutcome;
    }
}
