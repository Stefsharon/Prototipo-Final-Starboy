using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth = 3;
    public string playerName = "StarBoy";
    public int score = 0;
    public int laserquantity = 5;
    public bool HasKey = false;
    public bool isInvulnerable = false;

    public Action<int> OnTakeDamage;
    public Action<int> OnSetHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        OnSetHealth?.Invoke(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            TakeDamage(2);
        }
    }


    public void TakeDamage(int damage)
    {
        if(isInvulnerable) return;

        if (currentHealth <= 0) return;

        currentHealth -= damage;
        OnTakeDamage?.Invoke(damage);
        if (currentHealth <= 0)
        {
            Debug.Log("Game Over");
            gameObject.SetActive(false);
            SceneTransitionManager.Instance.LoadSceneWithLoadingScreen(SceneManager.GetActiveScene().name);
        }
    }

    public void AddScore(int points)
    {
        score += points;
    }
}
