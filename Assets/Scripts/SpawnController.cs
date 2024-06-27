using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    #region Private Variables
    [Header("GameObject Components")]
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _enemyMaxSize;
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();

    #endregion

    #region Private Methods
    private void Start()
    {
        SpawnEnemies();
    }
    
    private void SpawnEnemies()
    {
        int totalEnemiesSpawned = 0;

        foreach (Transform spawnPoint in _spawnPoints)
        {
            // Determine the number of enemies to spawn at this spawn point (between 1 and 3)
            int enemiesToSpawn = Random.Range(1, 4);

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                if (totalEnemiesSpawned >= _enemyMaxSize)
                {
                    return;
                }

                // Generate a random position near the spawn point within a certain range
                Vector3 randomPosition = spawnPoint.position + new Vector3(
                    Random.Range(-5f, 5f),
                    0,
                    Random.Range(-5f, 5f)
                );

                // Instantiate the enemy prefab at the random position with no rotation
               GameObject obj =  Instantiate(_enemyPrefab, randomPosition, Quaternion.identity);
                obj.transform.SetParent(spawnPoint);

                totalEnemiesSpawned++;
            }
        }

    }
    #endregion
}
