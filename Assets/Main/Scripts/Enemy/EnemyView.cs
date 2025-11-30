using System.Collections;
using UnityEngine;

public class EnemyView : MonoBehaviour
{

    Animator animator;
    public SpriteRenderer spriteRenderer;

    [Header("Flip")]
    private float initialXPos;
    private const float Epsilon = 0.0001f;

    Enemy enemy;
    EnemyHealth enemyHealth;

    Coroutine blinkOnHit;

    [Header("Attacks")]
    public string[] attacksTriggersName;
    void Start()
    {
        enemy = GetComponent<Enemy>();
        animator = GetComponentInChildren<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();

        enemy.OnPatrol += OnMove;
        enemy.OnChase += OnMove;
        enemy.OnAttack += OnStopMove;
        enemy.OnAttack += OnAttack;
        enemy.OnPreAttack += OnStopMove;
        enemy.OnIdle += OnStopMove;
        enemy.OnDead += OnStopMove;
        enemy.OnDead += OnDead;

        enemyHealth.OnTakeDamage += OnHit;
        enemyHealth.OnTakeDamage += OnStopMove;


        initialXPos = transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        Flip();
    }


    public void OnMove()
    {
        animator.SetBool("IsMoving", true);
    }

    public void OnStopMove()
    {
        animator.SetBool("IsMoving", false);
    }

    public void Flip()
    {
        float actualXPos = transform.position.x;
        float Xdirection = actualXPos - initialXPos;

        if (Xdirection < -Epsilon) spriteRenderer.flipX = true;   // yendo a la izquierda
        else if (Xdirection > Epsilon) spriteRenderer.flipX = false;  // yendo a la derecha

        initialXPos = actualXPos;
    }

    public void OnAttack()
    {
        string attackTrigger = attacksTriggersName[Random.Range(0, attacksTriggersName.Length)];

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
}
