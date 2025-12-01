using TMPro;
using UnityEngine;

public class Jail : MonoBehaviour
{
    private bool playerInRange = false;
    PlayerStats playerStats;

    public Andromaco andromaco;
    public TextMeshProUGUI textPickup;
    public GameObject textPickupObj;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            playerStats = collision.GetComponent<PlayerStats>();
            textPickup.text = playerStats.HasKey ? "E: Free Andromaco" : "You need a key";
            textPickupObj.SetActive(true);
           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            playerStats = null;
            textPickupObj.SetActive(false);
            
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
