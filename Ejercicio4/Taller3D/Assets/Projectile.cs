using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float lifeTime = 5f;

    private int damage;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void SetDamage(int cantidad)
    {
        damage = cantidad;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Entity entity = collision.gameObject.GetComponent<Entity>();

        if (entity != null)
        {
            entity.RecieveDMG(damage);
        }

        Destroy(gameObject);
    }
}