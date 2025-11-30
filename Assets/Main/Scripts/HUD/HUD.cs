using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class HUD : MonoBehaviour
{
    [SerializeField]PlayerStats playerStats;
    
    [SerializeField] List<GameObject> healthImages = new List<GameObject>();

    List<GameObject> healthActiveImages = new List<GameObject>();

    private void Awake()
    {
        if(playerStats == null) playerStats = FindFirstObjectByType<PlayerStats>();

        playerStats.OnSetHealth += SetHealthImages;
        playerStats.OnTakeDamage += DeleteImageOnTakeDamage;
    }
    


    public void SetHealthImages(int health)
    {
        for (int i = 0; i < health; i++)
        {
            healthActiveImages.Add(healthImages[i]);
            healthImages[i].SetActive(true);

        }
    }

    public void DeleteImageOnTakeDamage(int damage)
    {
        

        for (int i = 0; i < damage; i++)
        {
            if (healthActiveImages.Count == 0) return;
            healthActiveImages[healthActiveImages.Count - 1].SetActive(false);
            healthActiveImages.RemoveAt(healthActiveImages.Count - 1);
        }
        
       
    }
}
