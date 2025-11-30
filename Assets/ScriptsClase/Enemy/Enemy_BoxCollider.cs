using UnityEngine;

public class Enemy_BoxCollider : MonoBehaviour
{
    public bool alreadyHit = false;
    public int damage;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player_stats playerStats = collision.GetComponent<Player_stats>();
            if(playerStats != null && !alreadyHit)
            {
                playerStats.TakeDamage(damage);
                alreadyHit = true;
            }
        }
    }
}
