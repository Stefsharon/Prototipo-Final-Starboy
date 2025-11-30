using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionManager_clase : MonoBehaviour
{
    public static SceneTransitionManager_clase Instance;


    [Header("Fade Transition")]
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private string firstSceneToLoad = "NewScene";


    [Header("Loading UI")]
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Image progressBar;
    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] private TextMeshProUGUI tipsText;

    [Header("Actions")]
    public Action OnPlayerDie;


    [Header("Tips")]
    string[] tips =
    {
        "Tip 1: Remember to save your game often!",
        "Tip 2: Use cover to avoid enemy fire.",
        "Tip 3: Explore the environment for hidden items.",
        "Tip 4: Upgrade your skills to become stronger.",
        "Tip 5: Manage your resources wisely."
    };

    bool IsFirstScene = false;
    Canvas canvas;


    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if(fadeImage == null)
            fadeImage = GetComponentInChildren<Image>(true);
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            LoadSceneWithLoadingScreen("claseIntroScene");
        }
    }


    public void LoadSceneWithLoadingScreen(string sceneName)
    {
        StartCoroutine(FadeOutLoadSceneAsync(sceneName));
    }

    private IEnumerator FadeIn()
    {
        yield return Fade(1, 0);
    }


    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsed = 0f;
        Color color = fadeImage.color;

        while(elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / fadeDuration);
            fadeImage.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        fadeImage.color = new Color(color.r, color.g, color.b, endAlpha);
    }

    public void GetRandomTip()
    {
        int randomIndex = UnityEngine.Random.Range(0, tips.Length);
        tipsText.text = tips[randomIndex];
    }

    private void UpdateLoadingUI(float progress)
    {
        if(progressBar != null)
        {
            progressBar.fillAmount = progress;
        }

        if(progressText != null)
        {
            progressText.text = Mathf.RoundToInt(progress * 100f) + "%";
        }
    }


    private IEnumerator FadeOutLoadSceneAsync(string sceneName)
    {
        yield return Fade(0, 1);
        
        if(loadingScreen != null)
        {
            loadingScreen.SetActive(true);
        }

        GetRandomTip();

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        float displayProgress = 0f;

        while(operation.progress < 0.9f)
        {
            float targetProgress = Mathf.Clamp01(operation.progress / 0.9f);
            displayProgress = Mathf.MoveTowards(displayProgress, targetProgress, Time.deltaTime * 1.5f);
            UpdateLoadingUI(displayProgress);
            yield return null;
        }

        while(displayProgress < 1f)
        {
            displayProgress = Mathf.MoveTowards(displayProgress, 1f, Time.deltaTime * 0.5f);
            UpdateLoadingUI(displayProgress);
            yield return null;
        }

        yield return new WaitForSeconds(0.3f);

        operation.allowSceneActivation = true;
        yield return null;

        if(loadingScreen != null)
        {
            loadingScreen.SetActive(false);
        }

        IsFirstScene = false;

        yield return Fade(1, 0);
    }
}
