using TMPro;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool playerInRange = false;
    private PlayerStats playerStats;

    public GameObject textPickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            playerStats = collision.GetComponent<PlayerStats>();
            textPickup.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            playerStats = null;
            textPickup.SetActive(false);
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (playerStats != null)
            {
                playerStats.HasKey = true;
                Destroy(gameObject);
            }
        }
    }
}
