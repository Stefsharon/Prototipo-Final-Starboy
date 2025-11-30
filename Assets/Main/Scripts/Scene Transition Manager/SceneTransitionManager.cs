using System;
using System.Collections;
using TMPro;

using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;

    [Header("Fade")]
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
    string[] tips = {
        "¡Cuidado con los hongos rosas!",
        "¡Llegá hasta el final para avanzar de nivel!",
        "¡Derrota a la Horda de la Furia!",
        "La Ciudad de la Furia está bajo el poder de Typhon y la Horda de la Furia, derrotálos y rescatá a todos.",
        "Tu amigo Andrómaco fue secuestrado por Typhon y la Horda de la Furia ¡Buscálo, Starboy!"
    };

    bool IsFirstScene = true;
    Canvas canvas;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (fadeImage == null)
            fadeImage = GetComponentInChildren<Image>(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            LoadSceneWithLoadingScreen("MainScene");
        }
    }

    private void Start()
    {
        
    }

    public void LoadSceneWithLoadingScreen(string sceneName)
    {
        
        StartCoroutine(FadeOutLoadSceneAsync(sceneName));
    }

    private IEnumerator FadeIn()
    {
        yield return Fade(1, 0);
    }

    private IEnumerator FadeOutLoadSceneAsync(string sceneName)
    {
       
            yield return Fade(0, 1);

        if (loadingScreen != null)
            loadingScreen.SetActive(true);

        GetRandomTip();

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        float displayProgress = 0f;

        while (operation.progress < 0.9f)
        {
            float targetProgress = Mathf.Clamp01(operation.progress / 0.9f);
            displayProgress = Mathf.MoveTowards(displayProgress, targetProgress, Time.deltaTime * 1.5f);

            UpdateLoadingUI(displayProgress);
            yield return null;
        }

        // Esperar a que el display llegue al 1 visualmente
        while (displayProgress < 1f)
        {
            displayProgress = Mathf.MoveTowards(displayProgress, 1f, Time.deltaTime * 0.5f);
            UpdateLoadingUI(displayProgress);
            yield return null;
        }

        // Esperar un poco más si querés
        yield return new WaitForSeconds(0.3f);

        operation.allowSceneActivation = true;
        yield return null;
        


        if (loadingScreen != null)
            loadingScreen.SetActive(false);

        IsFirstScene = false;

        yield return Fade(1, 0);
    }

 

    private void UpdateLoadingUI(float progress)
    {
        if (progressBar != null)
            progressBar.fillAmount = progress;

        if (progressText != null)
            progressText.text = Mathf.RoundToInt(progress * 100f) + "%";
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsed = 0f;
        Color color = fadeImage.color;

        while (elapsed < fadeDuration)
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


}
