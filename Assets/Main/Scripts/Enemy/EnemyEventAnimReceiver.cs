using UnityEngine;

public class EnemyEventAnimReceiver : MonoBehaviour
{
    EnemyAttack enemyAttack;

    

    private void Awake()
    {
       enemyAttack = GetComponentInParent<EnemyAttack>();
      
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
