using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifetime = 5f;

    private int damage;
    private Health owner;
    private bool hasOwner;
    private bool spent;

    public void Initialize(int amount, Health source = null)
    {
        damage = amount;
        owner = source;
        hasOwner = source != null;

        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        if (hasOwner && (owner == null || owner.IsDead))
        {
            Destroy(gameObject);
            return;
        }
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (spent) return;
        if (hasOwner && (owner == null || owner.IsDead)) return;
        PlayerHealth target = other.GetComponentInParent<PlayerHealth>();

        if (target != null)
        {
            spent = true;
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}


