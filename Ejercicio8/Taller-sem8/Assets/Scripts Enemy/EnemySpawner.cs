using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int enemyCount = 5;

    private void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            int spawnIndex = Random.Range(0, spawnPoints.Length);

            Instantiate(enemyPrefabs[enemyIndex],spawnPoints[spawnIndex].position,spawnPoints[spawnIndex].rotation);
        }
    }
}
