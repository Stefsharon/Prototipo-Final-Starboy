using System;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public int speed = 5;
   
    
    
    bool Moving = false;
    private float moveInput;

    public Rigidbody2D rb;

  public Transform groundCheck;
   float groundCheckRadius = 0.25f;
    public LayerMask whatIsGround;

    [Header("Jump")]
    public int jumpForce = 5;
   public int maxJumps = 2;
    public int jumpLeft;
    bool Jumping = false;

    [Header("Friction")]
    public Collider2D bodyCollider;
    public PhysicsMaterial2D groundFriction;
    public PhysicsMaterial2D airFrictionless;


    [Header("Fall")]
    public bool IsFalling = false;
    float fallThreshold = 0.05f;
    float riseHysteresis = 0.01f;



    bool isGrounded;


    [Header("Dash")]
    Player_Dash playerDash;

    [Header("Actions")]
    public Action<float,float> OnMovement;
    public Action OnJumping;
    public Action<bool> OnFall;


    private void Awake()
    {
        playerDash = GetComponent<Player_Dash>();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if(isGrounded && rb.linearVelocity.y == 0) jumpLeft = maxJumps;



        if (Input.GetButtonDown("Jump") && jumpLeft > 0) //Input.GetKeyDown("KeyCode.Space")
        {
            Jumping = true;
           
        }

        moveInput = Input.GetAxis("Horizontal");
        Moving = Mathf.Abs(moveInput) > 0.01f; // si hay input horizontal

        CheckFriction();
        CheckFall();
    }

    private void FixedUpdate()
    {
        Jump();
        Move();
    }


    public void Move()
    {
        if (Moving == false) return;

        if (!playerDash.IsDashing && playerDash != null)
            rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        float moveInputRaw = Input.GetAxisRaw("Horizontal");
        OnMovement?.Invoke(Mathf.Abs(moveInputRaw), moveInputRaw);
    }

    public void Jump()
    {
        if(!Jumping) return;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        OnJumping?.Invoke();

          Jumping = false;
        jumpLeft--;

    }


    public void CheckFriction()
    {
        if (isGrounded)
        {
            bodyCollider.sharedMaterial = groundFriction;
        }
        else
        {
            bodyCollider.sharedMaterial = airFrictionless;
        }
    }

    public void CheckFall()
    {
        float verticalVelocity = rb.linearVelocity.y;

        bool shouldFall = !isGrounded && verticalVelocity < -fallThreshold;
        bool shouldStopFalling = isGrounded || verticalVelocity > -riseHysteresis;

        if (shouldFall)
        {
            IsFalling = true;
        }
        else if (shouldStopFalling)
        {
            IsFalling = false;
        }

        OnFall?.Invoke(IsFalling);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);

        
    }


}
