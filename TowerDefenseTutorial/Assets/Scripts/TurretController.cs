using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {
        
    public float range = 15f;
    public float turnSpeed = 10f;
    public Transform pivot;

    private Transform target;
    private string enemyTag = "Enemy";
    
    void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        Transform nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if(distance <= range && distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestEnemy = enemy.transform;
            }
        }

        //target = (nearestEnemy) ? nearestEnemy.transform : null;
        target = nearestEnemy;
    }
	
	void Update () {
		if(target)
        {
            // Lock to Target
            Vector3 direction = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Vector3 rotation = Quaternion.Lerp(pivot.rotation, lookRotation, turnSpeed *  Time.deltaTime).eulerAngles;
            pivot.rotation = Quaternion.Euler(0f, rotation.y, 0f);            
        }
	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
