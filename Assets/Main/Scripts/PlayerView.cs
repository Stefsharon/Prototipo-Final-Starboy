using System.Collections;

using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    [Header("Movement ref")]
    public PlayerMovement movement;

    [Header("Dash ref")]
    public PlayerDash playerDash;

    [Header("Attack ref")]
    public PlayerAttack playerAttack;
    Coroutine endAttackCor;

    [Header("Health ref")]
    public PlayerStats playerHealth;


    [Header("Information")]
    public bool IsFlipped => spriteRenderer.flipX;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        playerDash = GetComponent<PlayerDash>();
        playerAttack = GetComponent<PlayerAttack>();
        playerHealth = GetComponent<PlayerStats>();
      
    }
    void Start()
    {
        movement.OnMovement += OnMove;
        movement.OnJump += OnJump;
        movement.OnLand += OnLand;
        movement.OnFall += OnFall;
        playerDash.OnDash += OnDash;
        playerAttack.OnAttack += OnAttack;
        playerHealth.OnTakeDamage += _ => OnHit();

       // movement.OnMovement += (_,__) => test();

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnMove(float speed,float direction)
    {
        animator.SetFloat("Speed", speed);

        if (direction < 0)
            spriteRenderer.flipX = true;
        else if (direction > 0)
            spriteRenderer.flipX = false;
    }

    public void OnJump()
    {
        animator.ResetTrigger("Jump");

        animator.SetTrigger("Jump");
    }

    public void OnLand(bool InAir)
    {
      

        animator.SetBool("IsInAir", InAir);
    }

    public void OnFall(bool Falling)
    {
        animator.SetBool("IsFalling", Falling);
    }

    public void OnDash()
    {
        animator.ResetTrigger("Jump");

        animator.SetTrigger("Dash");
    }

    public void OnAttack()
    {
        animator.ResetTrigger("Jump");
        animator.SetTrigger("Attack");
        animator.SetBool("IsAttacking", true);
        if (endAttackCor != null) StopCoroutine(endAttackCor);
        endAttackCor = StartCoroutine(EndAttack());
    }

    IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(0.34f);
        animator.SetBool("IsAttacking", false);
    }


    public void OnHit()
    {
        animator.SetTrigger("Hit");
    }

    public void test()
    {
        Debug.Log("Move");
    }
}
