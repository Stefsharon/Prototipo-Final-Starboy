using System.Collections;
using UnityEngine;

public class Enemy_View : MonoBehaviour
{
    Animator animator;
    public SpriteRenderer spriteRenderer;

    [Header("Flip")]
    private float initialXpos;
    const float Epsilon = 0.0001f;


    Enemy_StateMachine stateMachine;
    Enemy_health enemyHealth;

    Coroutine blinkOnHit;

    [Header("Attacks")]
    public string[] attackAnimations;
    void Start()
    {
        stateMachine = GetComponent<Enemy_StateMachine>();
        animator = GetComponentInChildren<Animator>();
        enemyHealth = GetComponent<Enemy_health>();


        stateMachine.OnPatrol += OnMove;
        stateMachine.OnChase += OnMove;
        stateMachine.OnAttack += OnAttack;
        stateMachine.OnAttack += OnStopMove;
        stateMachine.OnPreAttack += OnStopMove;
        stateMachine.OnIdle += OnStopMove;
        stateMachine.OnDead += OnDead;
        stateMachine.OnDead += OnStopMove;

        enemyHealth.OnTakeDamage += OnHit;
        enemyHealth.OnTakeDamage += OnStopMove;

        initialXpos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
     Flip();
    }

    public void Flip()
    {
        float actualXpos = transform.position.x;
        float Xdirection = actualXpos - initialXpos;

        if(Xdirection < -Epsilon) spriteRenderer.flipX = true;
        else if(Xdirection > Epsilon) spriteRenderer.flipX = false;

        initialXpos = actualXpos;
    }


    public void OnAttack()
    {
        string attackTrigger = attackAnimations[Random.Range(0, attackAnimations.Length)];
        animator.SetTrigger(attackTrigger);
    }

    public void OnDead()
    {
        animator.SetTrigger("Die");
    }

    public void OnHit()
    {
        if (blinkOnHit != null) StopCoroutine(blinkOnHit);
        blinkOnHit = StartCoroutine(blinkOnHit_Cor());
        animator.SetTrigger("Hit");
    }

    IEnumerator blinkOnHit_Cor()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    public void OnMove()
    {
        animator.SetBool("IsMoving",true);
    }

    public void OnStopMove()
    {
        animator.SetBool("IsMoving", false);
    }
}
