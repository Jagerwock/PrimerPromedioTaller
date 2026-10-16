using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float lifeTime = 3f;

    private float damage;

    public void Launch(float damage, float speed)
    {
        this.damage = damage;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.linearVelocity = transform.forward * speed;

        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger || other.CompareTag("Player")) return;

        if (other.TryGetComponent(out Health health))
            health.TakeDamage(damage);

        Destroy(gameObject);
    }
}
