using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] float speed = 1.0f;

    void Start()
    {
        transform.position = waypoints[0].position;
        
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[1].position, Time.deltaTime * speed);
        
    }
}
