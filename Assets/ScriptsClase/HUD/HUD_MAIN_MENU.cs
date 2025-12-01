using UnityEngine;
using UnityEngine.UI;

public class HUD_MAIN_MENU : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    


    public void OnClickStartGame()
    {
        SceneTransitionManager_clase.Instance.LoadSceneWithLoadingScreen("claseIntroScene");
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }
    }

    public void OnClickExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
