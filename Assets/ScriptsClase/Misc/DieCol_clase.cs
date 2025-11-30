using UnityEngine;

public class DieCol_clase : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player_stats player = collision.GetComponent<Player_stats>();
            if (player != null) player.TakeDamage(999);
        }
    }
}
