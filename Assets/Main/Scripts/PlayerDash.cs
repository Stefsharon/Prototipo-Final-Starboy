using System;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [Header("Dash")]
    public float dashSpeed = 18f;
    public float dashDuration = 0.15f;
    public float dashCooldown = 0.40f;

    public bool IsDashing { get; private set; }

    private Rigidbody2D rb;
    private float originalGravity;
    private float cdTimer;     // cooldown restante
    private float durTimer;    // duración restante
    private int lastDir = 1;   // -1 izquierda, 1 derecha

    [Header("Actions")]
    public Action OnDash;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravity = rb.gravityScale;
    }

    void Update()
    {
        // Guardamos la última dirección válida del input horizontal
        float h = Input.GetAxisRaw("Horizontal");
        if (h != 0) lastDir = h > 0 ? 1 : -1;

        // bajamos cooldown
        if (cdTimer > 0f) cdTimer -= Time.deltaTime;

        // iniciar dash si hay cd listo
        if (Input.GetKeyDown(KeyCode.LeftShift) && cdTimer <= 0f && !IsDashing)
        {
            StartDash();
        }
    }

    void FixedUpdate()
    {
        if (!IsDashing) return;

        // velocidad constante durante el dash (recta y limpia)
        rb.linearVelocity = new Vector2(dashSpeed * lastDir, 0f);

       

        durTimer -= Time.fixedDeltaTime;
        if (durTimer <= 0f)
        {
            EndDash();
        }
    }

    private void StartDash()
    {
        IsDashing = true;
        durTimer = dashDuration;
        cdTimer = dashCooldown;

        // opcional: anulamos gravedad para que sea una línea recta
        rb.gravityScale = 0f;
        // opcional: quitamos cualquier velocidad previa vertical
        rb.linearVelocity = new Vector2(dashSpeed * lastDir, 0f);
        OnDash?.Invoke();
    }

    private void EndDash()
    {
        IsDashing = false;
        rb.gravityScale = originalGravity;
        // opcional: mantener un poco de inercia horizontal al salir
        // rb.velocity = new Vector2(dashSpeed * 0.4f * lastDir, rb.velocity.y);
    }
}
