
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    [SerializeField] private int damage = 10;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackCooldown = 1f;

    [SerializeField] private Transform player;

    private NavMeshAgent agent;
    private int currentHealth;
    private float nextAttackTime;
    private bool isDead;

    protected Transform Player => player;
    protected int Damage => damage;
    protected float AttackRange => attackRange;
    protected NavMeshAgent Agent => agent;

    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
    }

    protected virtual void Update()
    {
        if (isDead || player == null || agent == null)
            return;

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
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

    protected abstract void Attack();

    public void TakeDamage(int amount)
    {
        if (isDead || amount <= 0)
            return;

        currentHealth -= amount;

        if (currentHealth <= 0) 
            Die();
    }

    protected virtual void Die()
    {
        isDead = true;

        if (agent != null) agent.isStopped = true;

        Destroy(gameObject);
    }
}
