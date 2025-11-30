using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    public float attackRadius = 1.5f;
    public bool playerInRange = false;


    [Header("Attack Settings")]

    public float attackCooldown = 2f;
    float attackTimer = 0f;
    public int damage = 1;
    public BoxCollider2D attackBox;
    Vector2 originalBoxPos;

    public SpriteRenderer spriteRenderer;
    void Start()
    {
        originalBoxPos = attackBox.transform.localPosition;
    }

    
    void Update()
    {
        CheckPlayerInRange();
    }

    public void CheckPlayerInRange()
    {
        playerInRange = Physics2D.OverlapCircle(transform.position, attackRadius, LayerMask.GetMask("Player"));
    }

    public bool CanAttack()
    {
        if (attackTimer <= 0)
        {
            attackTimer = attackCooldown;
            return true;
        }
        else
        {
            attackTimer -= Time.deltaTime;
            return false;
        }
    }


    public void EnableCollider()
    {
        SetBoxPositionOnFlip();
        attackBox.GetComponent<Enemy_BoxCollider>().damage = damage;
        attackBox.GetComponent<Enemy_BoxCollider>().alreadyHit = false;
        attackBox.enabled = true;
    }

    public void DisableCollider()
    {
        attackBox.enabled = false;
    }


    public void SetBoxPositionOnFlip()
    {
        if (spriteRenderer.flipX)
        {
            attackBox.transform.localPosition = new Vector2(-originalBoxPos.x, originalBoxPos.y);
        }
        else
        {
            attackBox.transform.localPosition = originalBoxPos;
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
