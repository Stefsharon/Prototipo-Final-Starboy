using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [Header("refs")]
    PlayerDash playerDash;
    public Rigidbody2D rb;
    PlayerView playerView;

    public int damage = 1;

    public float AttackCD = 0.5f;
    float AttackCDTimer;

    public BoxCollider2D attackBox;
    Vector2 originalBoxPosition;

    [Header("Actions")]
    public Action OnAttack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerDash = GetComponent<PlayerDash>();
        rb = GetComponent<Rigidbody2D>();
        playerView = GetComponent<PlayerView>();

        originalBoxPosition = attackBox.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(AttackCDTimer > 0) AttackCDTimer -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Mouse0) && AttackCDTimer <= 0 && !playerDash.IsDashing)
        {
            Attack();
        }
    }

    public void EnableAttackBox()
    {
        attackBox.enabled = true;
    }

    public void DisableAttackBox()
    {
        attackBox.enabled = false;
    }

    public void Attack()
    {
       SetBoxPositionOnFlip();
        OnAttack?.Invoke();
        AttackCDTimer = AttackCD;
    }

    public void SetBoxPositionOnFlip()
    {
        if (playerView.spriteRenderer.flipX)
        {
            attackBox.transform.localPosition = -originalBoxPosition;
        }
        else
        {
            attackBox.transform.localPosition = originalBoxPosition;
        }
    }
}
