using UnityEngine;

public class EnemyBoxCollider : MonoBehaviour
{
    public bool alreadyHit = false;
    public int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.CompareTag("Player"))
        {
            PlayerStats playerStats = collision.GetComponent<PlayerStats>();
            if (playerStats != null && !alreadyHit)
            {
                playerStats.TakeDamage(damage);
                alreadyHit = true;
            }
        }
    }
}
