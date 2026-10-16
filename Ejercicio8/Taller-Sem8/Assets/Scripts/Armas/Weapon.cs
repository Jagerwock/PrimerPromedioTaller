using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [Header("Base")]
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected float fireRate = 0.25f;
    [SerializeField] protected float damage = 10f;
    public string WeaponName = "Arma";

    private float nextFireTime;

    public void TryShoot()
    {
        if (Time.time < nextFireTime) return;
        nextFireTime = Time.time + fireRate;
        Fire();
    }

    protected abstract void Fire();
}
