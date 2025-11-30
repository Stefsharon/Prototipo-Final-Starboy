using System;
using UnityEngine;

public enum EnemyState
{  
    Idle,
    Patrol,
    Chase,
    Attack,
    Dead
}

public class Enemy : MonoBehaviour
{

    public EnemyState currentState;

    [Header("Actions")]
    public Action OnIdle;
    public Action OnPatrol;
    public Action OnChase;
    public Action OnAttack;
    public Action OnPreAttack;
    public Action OnDead;


    EnemyPatrol enemyPatrol;
    EnemyChase enemyChase;
    EnemyAttack enemyAttack;
    EnemyHealth enemyHealth;


    [Header("References")]
    public CapsuleCollider2D capsuleCol;
    private bool hasDropped = false;

    private void Awake()
    {
        enemyPatrol = GetComponent<EnemyPatrol>();
        enemyChase = GetComponent<EnemyChase>();
        enemyAttack = GetComponent<EnemyAttack>();
        enemyHealth = GetComponent<EnemyHealth>();

        capsuleCol = GetComponent<CapsuleCollider2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine();
        CheckDie();
       
    }


    public void ChangeState(EnemyState newState)
    {
        currentState = newState;
    }

    public void StateMachine()
    {
         switch (currentState)
        {
            case EnemyState.Idle:
                OnIdle?.Invoke();
                if(enemyChase.playerDetected == true) currentState = EnemyState.Chase;
                if(enemyAttack.playerInRange == true) currentState = EnemyState.Attack;


                break;
            case EnemyState.Patrol:
                enemyPatrol.Patrol();
                OnPatrol?.Invoke();

                if (enemyChase.playerDetected == true) currentState = EnemyState.Chase;
                if (enemyAttack.playerInRange == true) currentState = EnemyState.Attack;

                break;
            case EnemyState.Chase:
                OnChase?.Invoke();
                enemyChase.Chase();

                if (enemyChase.playerDetected == false) currentState = EnemyState.Patrol;
                if (enemyAttack.playerInRange == true) currentState = EnemyState.Attack;
                break;
            case EnemyState.Attack:

                OnPreAttack?.Invoke();
                
                if (enemyAttack.playerInRange == false) currentState = EnemyState.Chase;

                if (!enemyAttack.CanAttack()) return;
                OnAttack?.Invoke();
                
                
                break;
            case EnemyState.Dead:
                if (!hasDropped)
                {
                    hasDropped = true;
                    OnDead?.Invoke();
                }
                capsuleCol.enabled = false;
                
                break;
        }
    }


    public void CheckDie()
    {
        if (enemyHealth.currentHealth <= 0) currentState = EnemyState.Dead;
    }



}
