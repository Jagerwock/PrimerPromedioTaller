using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifetime = 5f;

    private int damage;

    public void Initialize(int amount)
    {
        damage = amount;

        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth target = other.GetComponentInParent<PlayerHealth>();

        if (target != null)
        {
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}


