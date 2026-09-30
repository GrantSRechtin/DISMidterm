using System;
using System.Collections;
using UnityEngine;

public class FallAfterUse : MonoBehaviour
{
    [SerializeField] private float breakThreshold = 100;
    [SerializeField] private float fallTicks = 28;
    [SerializeField] private Vector3 finalRotation = new(0,0,-90);

    private int internalNum = 0;
    private Vector3 rotationShift = new(0f,0f,-20f);
    private Vector3 shift = new(0f,0f,0f);

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        shift = rotationShift / Math.Max((breakThreshold / 10) - 1,1);
    }

    public void Step()
    {
        internalNum++;

        if (internalNum >= breakThreshold)
        {
            GetComponentInParent<Collider2D>().enabled = false;
            StartCoroutine(Fall());
        }
        else if (internalNum >= 1 && internalNum % 10 == 0)
        {
            transform.Rotate(shift);
        }
    }

    IEnumerator Fall()
    {
        rb.simulated = true;
        rb.AddForceY(1, ForceMode2D.Impulse);
        rb.AddTorque(DetermineTorque(), ForceMode2D.Impulse);

        for (int i = 0; i < fallTicks; i++)
        {
            transform.Rotate(0,45/fallTicks,0);
            yield return new WaitForFixedUpdate();
        }

        rb.simulated = false;
    }

    private float DetermineTorque()
    {
        // Used AI to help with math

        // Goal was essentially to determine what torque should be added in order
        // to rotate (finalRotation - rotationShift) degrees over fallTicks ticks

        float deltaRadians = Mathf.DeltaAngle(rb.rotation, finalRotation.z) * Mathf.Deg2Rad;
        float duration = fallTicks * Time.fixedDeltaTime;
        return rb.inertia * deltaRadians / duration;
    }
}
