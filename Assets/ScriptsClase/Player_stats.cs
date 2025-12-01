using System;
using UnityEngine;


public class Player_stats : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth = 3;

    public string playerName = "Starboy";

    public int score = 0;

    public int laserQuantity = 3;

    public bool hasKey = false;


    public Action<int> OnTakeDamage;
    public Action<int> OnSetHealth;

    void Start()
    {
        currentHealth = maxHealth;
        OnSetHealth?.Invoke(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2)) TakeDamage(1);

       

        
    }

    public void TakeDamage(int damage)
    {
       currentHealth -= damage;
        OnTakeDamage?.Invoke(damage);
        if (currentHealth <= 0)
        {
            Debug.Log("Game Over");
            gameObject.SetActive(false);
            SceneTransitionManager_clase.Instance.LoadSceneWithLoadingScreen("claseIntroScene");
        }
    }

    public void AddScore(int points)
    {
        score += points;
    }







   



}
