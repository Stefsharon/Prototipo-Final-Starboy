using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class HUD_Clase : MonoBehaviour
{
   [SerializeField] Player_stats player_stats;

    [SerializeField] List<GameObject> healthImages = new List<GameObject>();

    List<GameObject> healthActiveImages = new List<GameObject>();

    private void Awake()
    {
        if(player_stats == null) player_stats = FindFirstObjectByType<Player_stats>();

        player_stats.OnSetHealth += SetHealthImages;
        player_stats.OnTakeDamage += DeleteImageOnTakeDamage;
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
            if(healthActiveImages.Count == 0) return;
            healthActiveImages[healthActiveImages.Count - 1].SetActive(false);
            healthActiveImages.RemoveAt(healthActiveImages.Count - 1);
        }
    }
}
