using UnityEngine;

public class DropKey_Enemy : MonoBehaviour
{
    Enemy_StateMachine enemy;

    public GameObject keyPrefab;

    private void Awake()
    {
        enemy = GetComponent<Enemy_StateMachine>();
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
