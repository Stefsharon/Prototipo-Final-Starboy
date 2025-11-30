using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [Header("Detection")]
    public float detectionRange = 5f;
    
    public bool playerDetected = false;
    public float timerCD = 1f;
    float timer = 0f;
    


    [Header("Chase")]
    public Transform playerTransform;
    public float chaseSpeed = 3f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public Transform groundCheck2;

    public float groundCheckRadius = 0.2f;

    void Start()
    {
        if(playerTransform == null) playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDetection();
        
    }

    public void PlayerDetection()
    {
        

        if(Physics2D.OverlapCircle(transform.position, detectionRange, LayerMask.GetMask("Player")) && IsGrounded())
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)

                playerDetected = true;
           


        }
        else
        {
            
            
                timer = timerCD;
            
            playerDetected = false;
        }
        
       
    }





    public bool IsGrounded()
    {
        bool firstCheck = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, LayerMask.GetMask("Ground"));
        bool secondCheck = Physics2D.OverlapCircle(groundCheck2.position, groundCheckRadius, LayerMask.GetMask("Ground"));

        if (firstCheck && secondCheck)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Chase()
    {
        if (playerTransform == null) return;
        // Posición actual (solo nos importa X)
        Vector2 pos = transform.position;

        // Objetivo: misma Y actual, X del jugador
        Vector2 target = new Vector2(playerTransform.position.x, pos.y);

        // Distancia horizontal pura
        float dx = Mathf.Abs(playerTransform.position.x - pos.x);

        // Si todavía está lejos en X, avanzar SOLO en X
        if (dx > 1.5f)
        {
            transform.position = Vector2.MoveTowards(pos, target, chaseSpeed * Time.deltaTime);
        }
        // Si querés: else -> cambiar a Attack o Idle según tu lógica




    }




    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheck2.position, groundCheckRadius);

        
    }

}
