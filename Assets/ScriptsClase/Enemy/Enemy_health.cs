using System;
using UnityEngine;

public class Enemy_health : MonoBehaviour
{

    public int maxHealth = 3;
    public int currentHealth;

    public Action OnTakeDamage;

    void Start()
    {
        currentHealth = maxHealth;
    }

    
    void Update()
    {
        
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        OnTakeDamage?.Invoke();
        if (currentHealth <= 0)
        {
            Die();
        }
    }


    public void Die()
    {
        Destroy(gameObject,1.5f);
    }
}
