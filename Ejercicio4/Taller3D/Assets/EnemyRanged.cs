using UnityEngine;

public class EnemyRanged : Entity
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    [SerializeField] private float fireRate = 2f;
    [SerializeField] private float bulletSpeed = 15f;

    private float nextFireTime;

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Time.time < nextFireTime)
        {
            return;
        }

        if (bulletPrefab == null || firePoint == null)
        {
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);

        Projectile projectile = bullet.GetComponent<Projectile>();

        if (projectile != null)
        {
            projectile.SetDamage(damage);
        }

        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        if (bulletRigidbody != null)
        {
            bulletRigidbody.linearVelocity = firePoint.forward * bulletSpeed;
        }

        nextFireTime = Time.time + fireRate;
    }
}