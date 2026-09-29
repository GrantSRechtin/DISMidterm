using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class FallAfterUse : MonoBehaviour
{
    [SerializeField] private float breakThreshold = 40;


    private int internalNum = 0;

    private Vector3 positionShift = new(0f,-0.025f,0f);
    private Vector3 rotationShift = new(0f,0f,-10f);

    public void Step()
    {
        internalNum++;

        if (internalNum >= breakThreshold*3)
        {
            // thing
        }
        else if (internalNum / breakThreshold >= 1 && internalNum % breakThreshold == 0)
        {
            transform.position += positionShift;
            StartCoroutine(Shift());
        }
    }

    IEnumerator Shift()
    {
        Quaternion shift = Quaternion.Euler(rotationShift);
        for (int i = 0; i < 2; i++)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, shift, 1f);
            yield return new WaitForFixedUpdate();
        }
        rotationShift += rotationShift;
    }
}
