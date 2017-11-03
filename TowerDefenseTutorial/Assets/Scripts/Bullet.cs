using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 70f;
    public GameObject bulletParticlesPrefab;

    private Transform target;
	
    public void Seek(Transform _target)
    {
        target = _target;
    }

	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
	}

    void HitTarget ()
    {
       GameObject bulletParticles =  Instantiate(bulletParticlesPrefab, transform.position, transform.rotation);
        Destroy(bulletParticles, 2f);
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
