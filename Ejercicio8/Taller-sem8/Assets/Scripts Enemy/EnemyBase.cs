using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBase : Health
{
    [SerializeField] private int health = 100;
    [SerializeField] private int damage = 10;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private Transform player;

    private NavMeshAgent agent;
    private float nextAttackTime;
    private PlayerHealth playerHealth;

    protected Transform Player => player;
    protected int Damage => damage;
    protected virtual float AttackCooldown => attackCooldown;
    protected virtual float InitialAttackDelay => 0f;

    protected override void Awake()
    {
        maxHealth = health;
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
    }

    protected override void Start()
    {
        base.Start();
        if (player == null || !player.gameObject.scene.IsValid())
        {
            PlayerHealth target = FindFirstObjectByType<PlayerHealth>();
            if (target != null) player = target.transform;
        }

        if (player != null) playerHealth = player.GetComponent<PlayerHealth>();
        nextAttackTime = Time.time + InitialAttackDelay;
    }

    protected virtual void Update()
    {
        if (IsDead || player == null || playerHealth == null || playerHealth.IsDead
            || Time.timeScale <= 0f || agent == null || !agent.enabled || !agent.isOnNavMesh)
        {
            return;
        }

        float distance = Vector3.Distance(transform.position,player.position);

        if (distance > attackRange)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        else
        {
            agent.isStopped = true;

            if (Time.time >= nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + AttackCooldown;
            }
        }
    }

    protected abstract void Attack();

    public void TakeDamage(int amount)
    {
        if (amount > 0) base.TakeDamage(amount);
    }

    protected override void Die()
    {
        enabled = false;
        StopAllCoroutines();
        if (agent != null && agent.enabled && agent.isOnNavMesh) agent.isStopped = true;
        base.Die();
    }
}
