using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Grenade : MonoBehaviour
{
    [SerializeField] private float fuseTime = 1.5f;
    [SerializeField] private GameObject explosionEffectPrefab; 

    private float damage;
    private float radius;

    public void Launch(Vector3 force, float damage, float radius)
    {
        this.damage = damage;
        this.radius = radius;

        GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        Invoke(nameof(Explode), fuseTime);
    }

    private void Explode()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius);
        HashSet<Health> damaged = new HashSet<Health>(); 

        foreach (Collider hit in hits)
        {
            Health health = hit.GetComponentInParent<Health>();
            if (health != null && damaged.Add(health))
                health.TakeDamage(damage);
        }

        if (explosionEffectPrefab != null)
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
