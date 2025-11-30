using UnityEngine;

public class DropKeyEnemy : MonoBehaviour
{

    Enemy enemy;
    public GameObject keyPrefab;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }
    private void Start()
    {
        enemy.OnDead += DropKey;
    }
    public void DropKey()
    {
        Instantiate(keyPrefab, transform.position, Quaternion.identity);
    }

    
}
