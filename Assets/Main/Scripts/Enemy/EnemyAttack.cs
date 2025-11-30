using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public bool playerInRange = false;
    public float attackRadius = 1.5f;


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

    // Update is called once per frame
    void Update()
    {
        CheckPlayerInRange();
    }

    public void CheckPlayerInRange()
    {
        if(Physics2D.OverlapCircle(transform.position, attackRadius, LayerMask.GetMask("Player")))
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }
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
        attackBox.GetComponent<EnemyBoxCollider>().damage = damage;
        attackBox.GetComponent<EnemyBoxCollider>().alreadyHit = false;
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
            attackBox.transform.localPosition = -originalBoxPos;
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
