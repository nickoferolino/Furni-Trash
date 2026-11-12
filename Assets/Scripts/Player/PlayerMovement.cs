using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 moveDirection;

    [Header("Mouse Settings")]
    [SerializeField] private Vector2 mousePosition;

    [Header("References")]
    private PlayerInput playerInput;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        var controls = playerInput.controls.Player;
        controls.Move.performed += HandleMove;
        controls.Move.canceled += HandleMove;

    }

    private void OnDisable()
    {
        var controls = playerInput.controls.Player;
        controls.Move.performed -= HandleMove;
        controls.Move.canceled -= HandleMove;
    }


    void Start()
    {
        
        
    }

    private void Update()
    {
        GetMousePosition();
        LookToMouseDirection();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.linearVelocity = moveDirection * moveSpeed;
    }

    private void HandleMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>().normalized;
        
        //Debug.Log($"Move Direction: {moveDirection}");
    }

    public Vector2 GetMousePosition()
    {
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        mousePosition = new Vector2(mouseWorldPos.x, mouseWorldPos.y);
        
        return mousePosition;
    }

    void LookToMouseDirection()
    {
        float directionX = mousePosition.x - transform.position.x;

        if (directionX != 0f)
            spriteRenderer.flipX = directionX < 0f;
    }



}
