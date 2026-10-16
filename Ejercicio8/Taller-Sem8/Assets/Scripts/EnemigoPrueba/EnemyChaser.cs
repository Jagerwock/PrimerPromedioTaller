using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyChaser : MonoBehaviour
{
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private float contactDamage = 10f;
    [SerializeField] private float attackCooldown = 1f;

    private NavMeshAgent agent;
    private Transform target;
    private Health targetHealth;
    private float nextAttackTime;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
            targetHealth = player.GetComponent<Health>();
        }
    }

    private void Update()
    {
        if (target == null) return;

        agent.SetDestination(target.position);

        if (Vector3.Distance(transform.position, target.position) <= attackRange && Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackCooldown;
            if (targetHealth != null) targetHealth.TakeDamage(contactDamage);
        }
    }
}
