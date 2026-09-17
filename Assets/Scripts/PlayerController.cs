using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed=5f;
    
    [Header("Up Sprites")]
    [SerializeField] private Sprite up1;
    [SerializeField] private Sprite up2;

    [Header("Down Sprites")]
    [SerializeField] private Sprite Down1;
    [SerializeField] private Sprite down2;
   
    [Header("Left Sprites")]
    [SerializeField] private Sprite Left1;
    [SerializeField] private Sprite Left2;

    [Header("Right Sprites")]
    [SerializeField] private Sprite Right1;
    [SerializeField] private Sprite Right2;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
