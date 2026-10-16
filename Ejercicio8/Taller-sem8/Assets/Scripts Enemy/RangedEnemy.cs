
using UnityEngine;

public class RangedEnemy : EnemyBase
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;

    protected override void Attack()
    {
        if (Player == null || projectilePrefab == null || firePoint == null)
        {
            return;
        }

        Vector3 direction = Player.position - firePoint.position;
        direction.y = 0f;

        firePoint.rotation = Quaternion.LookRotation(direction);

        GameObject projectile = Instantiate(projectilePrefab,firePoint.position,firePoint.rotation);

        EnemyProjectile bullet =projectile.GetComponent<EnemyProjectile>();

        if (bullet != null)
        {
            bullet.Initialize(Damage);
        }
        else
        {
            Destroy(projectile);
        }
    }
}

