using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed = 10f;

    private Transform target;
    private int waypointIndex;

   void Start()
    {
        waypointIndex = 0;
        target = Waypoints.points[waypointIndex];
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, target.position) > 0.2f)
        {
            Vector3 movement = target.position - transform.position;
            transform.Translate(movement.normalized * speed * Time.deltaTime);
        } else
        {
            GetNextWayPoint();
        }        
    }

    void GetNextWayPoint()
    {
        if(waypointIndex < Waypoints.points.Length - 1)
        {
            waypointIndex += 1;
            target = Waypoints.points[waypointIndex];
        } else
        {
            Destroy(gameObject);
        }
    }
}
