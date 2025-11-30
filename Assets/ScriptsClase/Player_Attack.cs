using System;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{

    [Header("Refs")]
    Player_Dash playerDash;
    Player_view playerView;
    Rigidbody2D rb;

    [Header("Attack Config")]
    public int damage = 1;
    public float attackCD = 0.5f;
    public float attackCDTimer = 0f;

    public BoxCollider2D attackBox;
    public Vector2 boxOriginalPosition;


    [Header("Action")]
    public Action OnAttack;

    void Start()
    {
        playerDash = GetComponent<Player_Dash>();
        playerView = GetComponent<Player_view>();
        rb = GetComponent<Rigidbody2D>();

        boxOriginalPosition = attackBox.transform.localPosition;
    }

    
    void Update()
    {

        if(attackCDTimer > 0) attackCDTimer -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Mouse0) && attackCDTimer <= 0 && !playerDash.IsDashing)
        {
            Attack();
        }
    }

    public void Attack()
    {
         SetBoxPositionOnFlip();
        OnAttack?.Invoke();
         attackCDTimer = attackCD;
    }

    public void EnableBoxCollider()
    {
        attackBox.enabled = true;
    }

    public void DisableBoxCollider()
    {
        attackBox.enabled = false;
    }

    public void SetBoxPositionOnFlip()
    {
        if (playerView.spriteRenderer.flipX)
            attackBox.transform.localPosition = -boxOriginalPosition;
        else
            attackBox.transform.localPosition = boxOriginalPosition;
    }
}
