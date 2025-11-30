using System.Collections;
using UnityEngine;

public class Player_view : MonoBehaviour
{
   public Animator animator;
   public SpriteRenderer spriteRenderer;


    [Header("Movement ref")]
    public Player_Movement movement;

    [Header("Dash ref")]
    public Player_Dash dash;

    [Header("Attack ref")]
    public Player_Attack attack;
    Coroutine endAttackCor;

    private void Awake()
    {
        dash = GetComponent<Player_Dash>();
        movement = GetComponent<Player_Movement>();
        attack = GetComponent<Player_Attack>();

    }
    void Start()
    {
        movement.OnMovement += OnMove;
        movement.OnJumping += OnJump;
        dash.OnDash += OnDash;
        movement.OnFall += OnFall;
        attack.OnAttack += OnAttack;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnMove(float speed, float direction)
    {
        animator.SetFloat("Speed", speed);

        if (direction < 0)
            spriteRenderer.flipX = true;
        else if (direction > 0)
            spriteRenderer.flipX = false;
    }

    public void OnJump()
    {
        animator.SetTrigger("Jump");
    }

    public void OnDash()
    {
        animator.SetTrigger("Dash");
    }

    public void OnFall(bool isFalling)
    {
        animator.SetBool("IsFalling",isFalling);
    }

    public void OnAttack()
    {
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
}
