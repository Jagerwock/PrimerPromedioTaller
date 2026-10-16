using UnityEngine;

public class BulletWeapon : Weapon
{
    [Header("Bala")]
    [SerializeField] private Projectile bulletPrefab;
    [SerializeField] private float bulletSpeed = 25f;

    protected override void Fire()
    {
        Projectile bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.Launch(damage, bulletSpeed);
    }
}
