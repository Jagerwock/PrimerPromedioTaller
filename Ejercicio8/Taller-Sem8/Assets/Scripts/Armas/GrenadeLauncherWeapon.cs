using UnityEngine;

public class GrenadeLauncherWeapon : Weapon
{
    [Header("Granada")]
    [SerializeField] private Grenade grenadePrefab;
    [SerializeField] private float throwForce = 12f;
    [SerializeField] private float upwardForce = 4f;
    [SerializeField] private float explosionRadius = 4f;

    protected override void Fire()
    {
        Grenade grenade = Instantiate(grenadePrefab, firePoint.position, firePoint.rotation);
        Vector3 force = firePoint.forward * throwForce + Vector3.up * upwardForce;
        grenade.Launch(force, damage, explosionRadius);
    }
}
