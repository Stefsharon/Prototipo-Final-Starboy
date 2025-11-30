using UnityEngine;
using UnityEngine.UI;

public class HUDMainMenu : MonoBehaviour
{
    
   [SerializeField] Button startGameButton;
    [SerializeField] Button creditsButton;
    [SerializeField] Button exitButton;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnClickStartGame()
    {
        SceneTransitionManager.Instance.LoadSceneWithLoadingScreen("MainScene");
        startGameButton.interactable = false;
        creditsButton.interactable = false;
        exitButton.interactable = false;
    }

    public void OnClickExitGame()
    {
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}
