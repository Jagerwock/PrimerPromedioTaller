using UnityEngine;

public class MeleeEnemy : EnemyBase
{
    protected override void Attack()
    {
        if (Player == null)
        {
            return;
        }

        PlayerHealth target = Player.GetComponent<PlayerHealth>();

        if (target != null)
        {
            target.TakeDamage(Damage);
        }
    }
}
