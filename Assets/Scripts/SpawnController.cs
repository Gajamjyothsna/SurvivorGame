using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorGame
{
    public class SpawnController : MonoBehaviour
    {
        #region Private Variables
        [Header("GameObject Components")]
        [SerializeField] private SurvivorGameDataModel.PoolObjectType _enemyType;
        [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();
        private int _enemyMaxSize;
        #endregion

        #region Private Methods
        private void Start()
        {
            SpawnEnemies();
        }

        private void SpawnEnemies()
        {
            ShuffleSpawnPoints();

            int totalEnemiesSpawned = 0;

            _enemyMaxSize = ObjectPooling.Instance.pools.Find(x => x.PoolObjectType == _enemyType).capacity;

            foreach (Transform spawnPoint in _spawnPoints)
            {
                // Determine the number of enemies to spawn at this spawn point (between 1 and 10)
                int enemiesToSpawn = Random.Range(1, 2);

                for (int i = 0; i < enemiesToSpawn; i++)
                {
                    if (totalEnemiesSpawned >= _enemyMaxSize)
                    {
                        return;
                    }

                    // Generate a random position near the spawn point within a certain range
                    Vector3 randomPosition = spawnPoint.position + new Vector3(Random.Range(-5f, 5f),0, Random.Range(-5f, 5f));

                    // Instantiate the enemy prefab at the random position with no rotation
                    GameObject obj = ObjectPooling.Instance.SpawnFromPool(_enemyType, randomPosition, Quaternion.identity);

                    totalEnemiesSpawned++;
                }
            }

        }

        private void ShuffleSpawnPoints()
        {
            for (int i = 0; i < _spawnPoints.Count; i++)
            {
                Transform temp = _spawnPoints[i];
                int randomIndex = Random.Range(i, _spawnPoints.Count);
                _spawnPoints[i] = _spawnPoints[randomIndex];
                _spawnPoints[randomIndex] = temp;
            }
        }

        #endregion
    }
}