using UnityEngine;

public class Enemy_Chase : MonoBehaviour
{
    [Header("Detection")]
    public float detectionRange = 5f;

    public bool playerDetected = false;
    public float timerCD = 1f;
    public float timer = 0f;


    [Header("Chase")]
    public Transform playerTransform;
    public float chaseSpeed = 3f;

    [Header("GroundCheck")]
    public Transform groundCheck;
    public Transform groundCheck2;
    public float groundCheckRadius = 0.2f;
    void Start()
    {
        if(playerTransform == null) playerTransform = GameObject.FindWithTag("Player").transform;
    }

    
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

        if(firstCheck && secondCheck)
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
        Vector2 pos = transform.position;
       
        Vector2 target = new Vector2(playerTransform.position.x, pos.y);

        float dx = Mathf.Abs(playerTransform.position.x - pos.x);

        if(dx > 1.5f)
        {
            transform.position = Vector2.MoveTowards(pos, target, chaseSpeed * Time.deltaTime);
        }
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
