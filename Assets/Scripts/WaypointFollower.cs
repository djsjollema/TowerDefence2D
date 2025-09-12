using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaypointFollower : MonoBehaviour
{
    Path path;
    [SerializeField] float speed = 0.5f;
    [SerializeField] int nextWaypointIndex = 10;
    [SerializeField] float reachedWaypointClearance = 0.2f;
    [SerializeField] GameObject trump;
    Animator animator;

    private void Awake()
    {
        path = FindAnyObjectByType<Path>();
    }

    void Start()
    {
        animator = trump.GetComponent<Animator>();
        transform.position = path.waypoints[0].position;
        
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, path.waypoints[nextWaypointIndex].position, Time.deltaTime * speed);
        if (Vector3.Distance(transform.position, path.waypoints[nextWaypointIndex].position) < reachedWaypointClearance)
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

            if (nextWaypointIndex >= path.waypoints.Length)
            {
                Destroy(gameObject);
                //transform.position = waypoints[0].position;
                //nextWaypointIndex = 1;
            }
        }
    }
}
