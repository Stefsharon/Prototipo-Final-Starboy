using UnityEngine;

public class Enemy_EventAnimReceiver : MonoBehaviour
{
    Enemy_Attack enemyAttack;

    private void Awake()
    {
       enemyAttack = GetComponentInParent<Enemy_Attack>();
    }
   

    public void EnableCollider()
    {
        enemyAttack.EnableCollider();
    }

    public void DisableCollider()
    {
        enemyAttack.DisableCollider();
    }
}
