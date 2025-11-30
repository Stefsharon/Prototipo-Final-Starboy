using UnityEngine;

public class teleport_clase : MonoBehaviour
{
    public string sceneName;
    bool inTransition = false;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !inTransition)
        {
            inTransition = true;
            SceneTransitionManager_clase.Instance.LoadSceneWithLoadingScreen(sceneName);
        }
    }
}
