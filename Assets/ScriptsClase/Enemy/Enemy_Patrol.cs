using UnityEngine;

public class Enemy_Patrol : MonoBehaviour
{
    public float speed = 5f;
    public Transform[] waypoints;
    public int currentWaypointIndex = 0;


    private void Update()
    {
      
    }

    public void Patrol()
    {
        if(waypoints == null || waypoints.Length == 0) return;

        Vector3 target = waypoints[currentWaypointIndex].position;

        float distance = Vector3.Distance(transform.position, target);
        if(distance <= 0.2f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            target = waypoints[currentWaypointIndex].position;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
