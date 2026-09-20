using System;
using System.Data.Common;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed=5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    private void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    private void OnMove(InputValue input)
    {
        movement=input.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity=movement*moveSpeed;
    }

    public Vector2 GetMovementDirection()
    {
        return movement;
    }
}
