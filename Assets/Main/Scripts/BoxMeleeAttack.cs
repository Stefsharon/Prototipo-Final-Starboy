using UnityEngine;

public class BoxMeleeAttack : MonoBehaviour
{
    PlayerAttack playerAttack;

    public int damage;
    void Start()
    {
        if(playerAttack == null) playerAttack = GetComponentInParent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Debug.Log("Hit enemy");
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage(SetDamage());
            }
        }
    }


    public int SetDamage()
    {
        damage = playerAttack.damage;
        return damage;
    }
}
