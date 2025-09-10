using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] float speed = 1.0f;
    [SerializeField] int nextWaypointIndex = 10;
    [SerializeField] float reachedWaypointClearance = 0.2f;
    [SerializeField] GameObject trump;
    Animator animator;

    void Start()
    {
        animator = trump.GetComponent<Animator>();
        transform.position = waypoints[0].position;
        
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[nextWaypointIndex].position, Time.deltaTime * speed);
        if (Vector3.Distance(transform.position, waypoints[nextWaypointIndex].position) < reachedWaypointClearance)
        {
            nextWaypointIndex++;
            switch (nextWaypointIndex)
            {
                case 2:
                    animator.Play("upTrump");
                    break;
                case 4:
                    animator.Play("downTrump");
                    break;
                case 6:
                    animator.Play("upTrump");
                    break;
                default: animator.Play("LeftTrump");
                    break;

            }

            if (nextWaypointIndex >= waypoints.Length)
            {
                transform.position = waypoints[0].position;
                nextWaypointIndex = 1;
            }
        }
    }
}
