using System;
using System.Data.Common;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed=5f;
    
    [Header("Up Sprites")]
    [SerializeField] private Sprite up1;
    [SerializeField] private Sprite up2;

    [Header("Down Sprites")]
    [SerializeField] private Sprite Down1;
    [SerializeField] private Sprite down2;
   
    [Header("Side Sprites")]
    [SerializeField] private Sprite Side1;
    [SerializeField] private Sprite Side2;


    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector2 movement;

    private void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
        spriteRenderer=GetComponent<SpriteRenderer>();
    }

    private void OnMove(InputValue input)
    {
        movement=input.Get<Vector2>();
        UpdateSprite();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity=movement*moveSpeed;
    }

    private void UpdateSprite() //need to update this to animate through the sprites
    {
        if (movement == Vector2.zero)
        {
            return;
        }
        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            spriteRenderer.sprite=Side1;
            spriteRenderer.flipX=movement.x<0;
        }
        else
        {
            spriteRenderer.flipX=false;
            if(movement.y>0) spriteRenderer.sprite=up1;
            else if (movement.y>0) spriteRenderer.sprite=Down1;
        }
    }
}
