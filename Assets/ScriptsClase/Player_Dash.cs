using System;
using UnityEngine;

public class Player_Dash : MonoBehaviour
{
    public float dashSpeed = 18f;
    public float dashDuration = 0.15f;
    public float dashCooldown = 0.4f;


    public bool IsDashing { get; private set; }

    public Rigidbody2D rb;
    private float originalGravity;
    private float cdTimer;     // cooldown restante
    private float durTimer;    // duración restante
    private int lastDir = 1;   // -1 izquierda, 1 derecha


    [Header("Actions")]
    [SerializeField] public Action OnDash;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravity = rb.gravityScale;
    }

    
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if (h != 0) lastDir = h > 0 ? 1 : -1;

        if (cdTimer > 0f) cdTimer -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.LeftShift) && cdTimer <= 0f && !IsDashing)
        {
            StartDash();
        }
    }

    private void FixedUpdate()
    {
        if (!IsDashing) return;

        rb.linearVelocity = new Vector2(dashSpeed * lastDir, 0f);

        durTimer -= Time.fixedDeltaTime;
        if (durTimer <= 0f)
        {
            EndDash();
        }
    }


    public void StartDash()
    {
        IsDashing = true; // indicamos que estamos dashing
        durTimer = dashDuration;
        cdTimer = dashCooldown; // reiniciamos el cooldown
        OnDash?.Invoke(); // invocamos el evento OnDash

        rb.gravityScale = 0f; // desactivamos la gravedad
        rb.linearVelocity = new Vector2(dashSpeed * lastDir, 0f); // velocidad inicial
    }

    public void EndDash()
    {
               IsDashing = false;
        rb.gravityScale = originalGravity;
    }
}
