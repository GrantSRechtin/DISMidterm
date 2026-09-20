using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class Table : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject[] disabledGameObjects;
    [SerializeField] private Vector3 shift = new(0.5f,0.5f,0);
    [SerializeField] private float shiftSteps = 30;
    [SerializeField] private bool singleUse = true;

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

    void Awake(){}
    void Update(){}
    void FixedUpdate(){}
}
