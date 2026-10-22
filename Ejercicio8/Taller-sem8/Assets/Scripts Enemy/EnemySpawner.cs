using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int enemyCount = 5;
    [SerializeField] private HealthBar enemyBarPrefab;
    [SerializeField] private UnityEvent allEnemiesDefeated = new UnityEvent();

    private readonly HashSet<Health> living = new HashSet<Health>();
    private bool spawningFinished;
    private bool completed;

    public UnityEvent AllEnemiesDefeated => allEnemiesDefeated;

    private void Start()
    {
        if (!TryGetSpawnPositions(out Vector3[] positions)) return;

        for (int i = 0; i < enemyCount; i++)
        {
            int enemyIndex = UnityEngine.Random.Range(0, enemyPrefabs.Length);
            int spawnIndex = UnityEngine.Random.Range(0, spawnPoints.Length);

            GameObject enemy = Instantiate(enemyPrefabs[enemyIndex], positions[spawnIndex], spawnPoints[spawnIndex].rotation);
            Health health = enemy.GetComponent<Health>();
            living.Add(health);

            if (enemyBarPrefab != null && enemy.GetComponentInChildren<HealthBar>(true) == null)
            {
                HealthBar bar = Instantiate(enemyBarPrefab, enemy.transform);
                float height = enemy.TryGetComponent(out Collider collider)
                    ? collider.bounds.max.y - enemy.transform.position.y + 0.3f : 1.5f;
                bar.transform.localPosition = Vector3.up * height;
                bar.Bind(health);
            }
        }
        spawningFinished = true;
    }

    private bool TryGetSpawnPositions(out Vector3[] positions)
    {
        positions = null;
        if (enemyPrefabs == null || enemyPrefabs.Length == 0 || spawnPoints == null
            || spawnPoints.Length == 0 || enemyCount <= 0) return false;

        foreach (GameObject prefab in enemyPrefabs)
            if (prefab == null || !prefab.TryGetComponent<Health>(out _)) return false;

        positions = new Vector3[spawnPoints.Length];
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (spawnPoints[i] == null || !NavMesh.SamplePosition(spawnPoints[i].position, out NavMeshHit hit, 2f, NavMesh.AllAreas))
                return false;
            positions[i] = hit.position;
        }
        return true;
    }

    private void LateUpdate()
    {
        if (!spawningFinished || completed) return;
        living.RemoveWhere(health => health == null || health.IsDead);
        if (living.Count != 0) return;
        completed = true;
        allEnemiesDefeated.Invoke();
    }
}
