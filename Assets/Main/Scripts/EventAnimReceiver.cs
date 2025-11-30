using UnityEngine;

public class EventAnimReceiver : MonoBehaviour
{
    public PlayerAttack playerAttack;
    

    public void EnableAttackBox()
    {
        playerAttack.EnableAttackBox();
    }

    public void DisableAttackBox()
    {
        playerAttack.DisableAttackBox();
    }
}
