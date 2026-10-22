
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class BossPatterns : EnemyBase
{
    [FormerlySerializedAs("fibo1")]
    [SerializeField] private int previousBurstCount;
    [FormerlySerializedAs("fibo2")]
    [SerializeField] private int lastBurstCount = 1;
    [FormerlySerializedAs("maxFibVal")]
    [SerializeField] private int maxBurstCount = 3;
    [SerializeField] private float cooldown = 10f;
    [FormerlySerializedAs("timer")]
    [SerializeField] private float initialAttackDelay = 0.1f;
    [SerializeField] private float shotInterval = 0.2f;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float combatDistance = 7f;
    [SerializeField] private float retreatDistance = 4f;
    [SerializeField] private float movementStep = 2f;
    [SerializeField] private float strafeDuration = 3f;
    [SerializeField] private float arenaRadius = 16f;
    [SerializeField] private float fanAngle = 15f;

    public GameObject bulletPrefab;

    private NavMeshAgent agent;
    private PlayerHealth targetHealth;
    private Collider playerCollider;
    private Vector3 arenaCenter;
    private float nextAttackTime;
    private float nextMoveTime;
    private float nextStrafeTime;
    private int strafeDirection = 1;
    private int nextPattern;
    private bool attacking;

    protected override float AttackCooldown => cooldown;
    protected override float InitialAttackDelay => initialAttackDelay;

    protected override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();

        if (agent != null)
            agent.updateRotation = false;
    }

    protected override void Start()
    {
        base.Start();

        if (Player != null)
        {
            targetHealth = Player.GetComponent<PlayerHealth>();
            playerCollider = Player.GetComponent<Collider>();

            if (playerCollider == null)
                playerCollider = Player.GetComponentInChildren<Collider>();
        }

        arenaCenter = transform.position;
        nextAttackTime = Time.time + InitialAttackDelay;
        nextStrafeTime = Time.time + strafeDuration;
    }

    protected override void Update()
    {
        if (agent == null || !agent.enabled || !agent.isOnNavMesh)
            return;

        if (IsDead || Player == null || targetHealth == null ||
            targetHealth.IsDead || Time.timeScale <= 0f)
        {
            agent.isStopped = true;
            return;
        }

        Vector3 direction = Player.position - transform.position;
        direction.y = 0f;

        float distance = direction.magnitude;
        Vector3 towardPlayer = distance > 0.01f
            ? direction.normalized
            : transform.forward;

        if (distance > 0.01f)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                Quaternion.LookRotation(towardPlayer),
                agent.angularSpeed * Time.deltaTime
            );
        }

        if (Time.time >= nextMoveTime)
        {
            MoveBoss(towardPlayer, distance);
            nextMoveTime = Time.time + 0.25f;
        }

        if (distance <= combatDistance &&
            Time.time >= nextAttackTime && !attacking)
        {
            Attack();
            nextAttackTime = Time.time + AttackCooldown;
        }
    }

    private void MoveBoss(Vector3 towardPlayer, float distance)
    {
        if (Time.time >= nextStrafeTime)
        {
            strafeDirection *= -1;
            nextStrafeTime = Time.time + strafeDuration;
        }

        Vector3 goal;

        if (distance > combatDistance)
        {
            goal = Player.position;
        }
        else if (distance < retreatDistance)
        {
            goal = transform.position - towardPlayer * movementStep;
        }
        else
        {
            Vector3 sideways = Vector3.Cross(Vector3.up, towardPlayer);
            goal = transform.position + sideways * strafeDirection * movementStep;
        }

        Vector3 offset = goal - arenaCenter;
        offset.y = 0f;
        goal = arenaCenter + Vector3.ClampMagnitude(offset, arenaRadius);

        if (NavMesh.SamplePosition(goal, out NavMeshHit hit, 1.5f, agent.areaMask)
            && agent.SetDestination(hit.position))
        {
            agent.isStopped = false;
        }
        else
        {
            agent.isStopped = true;
            strafeDirection *= -1;
        }
    }

    protected override void Attack()
    {
        if (attacking || IsDead || bulletPrefab == null ||
            targetHealth == null || targetHealth.IsDead)
            return;

        StartCoroutine(FirePattern());
    }

    private IEnumerator FirePattern()
    {
        attacking = true;

        int pattern = nextPattern;
        nextPattern = (nextPattern + 1) % 3;

        if (pattern == 0)
            yield return DirectedBurst();
        else if (pattern == 1)
            FireSpread(5, fanAngle, -2f * fanAngle);
        else
            FireSpread(8, 45f, 0f);

        attacking = false;
    }

    private IEnumerator DirectedBurst()
    {
        int count = previousBurstCount + lastBurstCount;
        previousBurstCount = lastBurstCount;
        lastBurstCount = count;

        if (count >= maxBurstCount)
        {
            previousBurstCount = 0;
            lastBurstCount = 1;
        }

        for (int i = 0; i < count; i++)
        {
            if (IsDead || targetHealth == null || targetHealth.IsDead)
                yield break;

            Vector3 origin = firePoint != null
                ? firePoint.position
                : transform.position;

            FireProjectile(origin, TargetPosition - origin);

            if (i + 1 < count)
                yield return new WaitForSeconds(shotInterval);
        }
    }

    private void FireSpread(int count, float spacing, float startAngle)
    {
        Vector3 origin = firePoint != null
            ? firePoint.position
            : transform.position;

        Vector3 direction = TargetPosition - origin;

        for (int i = 0; i < count; i++)
        {
            Vector3 shot = Quaternion.AngleAxis(
                startAngle + spacing * i,
                Vector3.up
            ) * direction;

            FireProjectile(origin, shot);
        }
    }

    private Vector3 TargetPosition =>
        playerCollider != null ? playerCollider.bounds.center : Player.position;

    private void FireProjectile(Vector3 origin, Vector3 direction)
    {
        if (IsDead || bulletPrefab == null ||
            targetHealth == null || targetHealth.IsDead ||
            direction.sqrMagnitude < 0.001f)
            return;

        GameObject projectile = Instantiate(
            bulletPrefab,
            origin,
            Quaternion.LookRotation(direction)
        );

        if (projectile.TryGetComponent(out EnemyProjectile bullet))
            bullet.Initialize(Damage, this);
        else
            Destroy(projectile);
    }
}

