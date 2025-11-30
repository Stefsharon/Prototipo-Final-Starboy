using UnityEngine;

public class Jail : MonoBehaviour
{
    private bool playerInRange = false;
    PlayerStats playerStats;

    public Andromaco andromaco;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            playerStats = collision.GetComponent<PlayerStats>();
           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            playerStats = null;
            
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (playerStats != null)
            {
                if(playerStats.HasKey == true)
                {
                    andromaco.FreeAndromaco();
                    Destroy(gameObject);
                }
                    
            }
          

            
        }
    }
}
