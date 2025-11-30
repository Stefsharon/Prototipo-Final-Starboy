using UnityEngine;

public class jail_clase : MonoBehaviour
{
    bool playerInRange = false;
    Player_stats player;

    public andromaco_clase andromaco;

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




    void Update()
    {
        if(playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (player != null)
            {
                if(player.hasKey == true)
                {
                    andromaco.FreeAndromaco();
                    Destroy(gameObject);
                }
            }
        }
    }
}
