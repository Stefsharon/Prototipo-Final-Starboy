using UnityEngine;

public class Teleport : MonoBehaviour
{
    public string sceneName;
    bool inTransition = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (inTransition) return;
            inTransition = true;
            SceneTransitionManager.Instance.LoadSceneWithLoadingScreen(sceneName);
        }
    }
}
