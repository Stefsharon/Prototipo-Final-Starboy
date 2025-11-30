using UnityEngine;

public class key_clase : MonoBehaviour
{
    bool playerInRange = false;
    Player_stats player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            player = collision.GetComponent<Player_stats>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            player = null;
        }
    }


    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if(player == null) return;

            player.hasKey = true;
            Destroy(gameObject);
        }
    }
}
