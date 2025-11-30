using UnityEngine;

public class Attack_box : MonoBehaviour
{
    public Player_Attack playerAttack;
    void Start()
    {
        if(playerAttack == null) playerAttack = GetComponentInParent<Player_Attack>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
          
            Enemy_health enemyHealth = collision.GetComponent<Enemy_health>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(playerAttack.damage);
            }
        }
    }

    
}
