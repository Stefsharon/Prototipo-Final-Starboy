using UnityEngine;

public class DieCol : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {
            PlayerStats playerStats = collision.gameObject.GetComponent<PlayerStats>();

            if(playerStats != null)
            {
                playerStats.TakeDamage(999);
            }
        }
    }
}
