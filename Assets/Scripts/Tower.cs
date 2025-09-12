using UnityEngine;

public class Tower : MonoBehaviour
{
    
    void Update()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
        if(targets.Length == 0)
        {
            return; 
        }

        Transform target = targets[0].transform;
        LookAtTarget(target);

        
    }

    void LookAtTarget(Transform target)
    {
        Vector2 direction = target.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction); 
    }
}
