using UnityEngine;

public class Event_AnimReceiver : MonoBehaviour
{
    Player_Attack playerAttack;
    void Start()
    {
        playerAttack = GetComponentInParent<Player_Attack>();
    }

    public void EnableAttackBox()
    {
        playerAttack.EnableBoxCollider();
    }

    public void DisableAttackBox()
    {
        playerAttack.DisableBoxCollider();
    }
}
