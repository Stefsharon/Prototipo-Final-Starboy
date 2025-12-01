using UnityEngine;

public class Teleport : MonoBehaviour
{
    public string sceneName;
    bool inTransition = false;
    PlayerStats playerStats;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerStats = collision.GetComponent<PlayerStats>();
            
            if (inTransition) return;
            playerStats.isInvulnerable = true;
            inTransition = true;
            SceneTransitionManager.Instance.LoadSceneWithLoadingScreen(sceneName);
        }
    }
}
