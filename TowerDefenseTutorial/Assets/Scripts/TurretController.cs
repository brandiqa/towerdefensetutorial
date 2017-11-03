using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {
     
    [Header("Upgradeable Attributes")]
    // Target Locking Variables
    public float range = 15f;    
    public float fireRate = 1f;

    [Header("Unity Setup Fields")]
    public Transform pivot;
    public float turnSpeed = 10f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private Transform target;
    private string enemyTag = "Enemy";

    // Firing Mechanism Variables
    
    private float fireTimer = 0f;
    
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

        if(fireTimer <= 0f && target != null)
        {
            Shoot();
            fireTimer = 1f / fireRate;
        }

        fireTimer -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null) {
            bullet.Seek(target);
        }
       
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
