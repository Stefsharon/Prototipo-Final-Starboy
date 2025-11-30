using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 6f;
    public float jumpForce = 7f;

    [Header("Ground Check")]
    public Transform groundCheck;            // Empty child en los pies
    public float groundCheckRadius = 0.25f;  // Radio del c�rculo
    public LayerMask groundLayer; // Capa "Ground"
    private bool isGrounded;

    private Rigidbody2D rb;
    private float horizontalInput;

    [Header("Jump")]
    private bool jumpQueued;
    public int maxJumps = 2;
    public int jumpsLeft;

    [Header("Friction")]
    public Collider2D bodyCollider;                 // arrástralo desde el inspector
    public PhysicsMaterial2D airFrictionless;
    public PhysicsMaterial2D groundFriction;

    [Header("Dash")]
   public PlayerDash playerDash;

    [Header("Fall State")]
    public float fallThreshold = 0.05f;   // umbral para considerar "caer"
    public float riseHysteresis = 0.01f;  // histeresis para evitar flicker
    private bool isFalling;

    [Header("Actions")]

    public Action<float,float> OnMovement;
    public Action OnJump;
    public Action<bool> OnLand;
    public Action<bool> OnFall;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // Recomendado:
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.freezeRotation = true;
    }

    void Update()
    {
        // 1) Leo input en Update
        horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector3 moveX = transform.right * horizontalInput;
       // MoveTranslate(moveX);

        //movimiento sin fisicas
        //transform.Translate(horizontalInput * speed * Time.fixedDeltaTime, 0, 0);

        // 2) Queueo salto (para que se ejecute en FixedUpdate)
        if (Input.GetButtonDown("Jump") && jumpsLeft > 0)
            jumpQueued = true;


        // Chequeo si estoy en el aire para la animaci��n
        CheckIsInAir();
        // Chequeo si estoy cayendo
        CheckFall();
    }

    void FixedUpdate()
    {
        // 3) Chequeo suelo en FixedUpdate (f�sica 2D)
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded && rb.linearVelocityY == 0)
            jumpsLeft = maxJumps;


        // 4) Movimiento horizontal
        if (!playerDash.IsDashing && playerDash != null)
        {
            rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
            
            OnMovement?.Invoke(Mathf.Abs(horizontalInput), horizontalInput);
        }
       

       

        // 5) Salto
        if (jumpQueued)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // Reinicio velocidad Y
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            OnJump?.Invoke();
            jumpQueued = false;
            jumpsLeft--;

        }

        // 6) Friction
        CheckFriction();
    }

    public void MoveTranslate(Vector3 moveX)
    {
        transform.Translate(moveX * speed * Time.fixedDeltaTime);
    }

    public void CheckFriction()
    {
        if (isGrounded)
            bodyCollider.sharedMaterial = groundFriction;
        else
            bodyCollider.sharedMaterial = airFrictionless;
    }

    public void CheckIsInAir()
    {
        if(isGrounded)
            OnLand?.Invoke(false);
        else
            OnLand?.Invoke(true);
    }

    public void CheckFall()
    {
        float vy = rb.linearVelocity.y;

        bool shouldFall = !isGrounded && vy < -fallThreshold;
        bool shouldStopFalling = isGrounded || vy > -riseHysteresis;

        if (shouldFall) isFalling = true;
        if (shouldStopFalling) isFalling = false;

        OnFall?.Invoke(isFalling);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
