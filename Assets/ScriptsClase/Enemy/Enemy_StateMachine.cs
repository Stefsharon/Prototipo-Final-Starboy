using System;
using UnityEngine;

public enum Enemy_State
{  
    Idle,
    Patrol,
    Chase,
    Attack,
    Dead
}

public class Enemy_StateMachine : MonoBehaviour
{
    

    public Enemy_State currentState;

    [Header("Actions")]
    public Action OnIdle;
    public Action OnPatrol;
    public Action OnChase;
    public Action OnPreAttack;
    public Action OnAttack;
    public Action OnDead;


    Enemy_Patrol enemyPatrol;
    Enemy_Chase enemyChase;
    Enemy_Attack enemyAttack;
    Enemy_health enemyHealth;

    bool hasDropped = false;
    public CapsuleCollider2D capsuleCol;

    private void Awake()
    {
        enemyPatrol = GetComponent<Enemy_Patrol>();
        enemyChase = GetComponent<Enemy_Chase>();
        enemyAttack = GetComponent<Enemy_Attack>();
        enemyHealth = GetComponent<Enemy_health>();

        capsuleCol = GetComponent<CapsuleCollider2D>();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        StateMachine();
        CheckDie();
    }

    public void StateMachine()
    {
        switch (currentState)
        {
            case Enemy_State.Idle:
                OnIdle?.Invoke();
                if(enemyChase.playerDetected) currentState = Enemy_State.Chase;
                if (enemyAttack.playerInRange) currentState = Enemy_State.Attack;

                break;
            case Enemy_State.Patrol:
                enemyPatrol.Patrol();
                OnPatrol?.Invoke();

                if (enemyChase.playerDetected) currentState = Enemy_State.Chase;
                if (enemyAttack.playerInRange) currentState = Enemy_State.Attack;

                break;
            case Enemy_State.Chase:
                OnChase?.Invoke();
                enemyChase.Chase();

                if (!enemyChase.playerDetected) currentState = Enemy_State.Patrol;
                if (enemyAttack.playerInRange) currentState = Enemy_State.Attack;

                break;
            case Enemy_State.Attack:
                OnPreAttack?.Invoke();

                if (!enemyAttack.playerInRange) currentState = Enemy_State.Chase;

                if(!enemyAttack.CanAttack()) return;
                OnAttack?.Invoke();

                break;
            case Enemy_State.Dead:
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
        if (enemyHealth.currentHealth <= 0)
        {
            currentState = Enemy_State.Dead;
        }
    }
}
