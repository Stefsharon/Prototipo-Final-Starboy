using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    
    public float speed = 5f;
    public Transform[] waypoints;
    public int currentWaypointIndex = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Patrol()
    {
        if (waypoints == null || waypoints.Length == 0) return;

        // 1) waypoint objetivo actual
        Vector3 target = waypoints[currentWaypointIndex].position;

        // 2) si llegaste, avanzar al siguiente (una sola vez)
        float distance = Vector3.Distance(transform.position, target);
        if (distance <= 0.2f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            target = waypoints[currentWaypointIndex].position; // actualizar target
        }

        // 3) moverse hacia el target
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

    }

    
}
