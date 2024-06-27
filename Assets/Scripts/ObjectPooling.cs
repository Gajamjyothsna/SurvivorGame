using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorGame
{
    public class ObjectPooling : MonoBehaviour
    {
        #region Creating Instance
        private static ObjectPooling _objectPoolingInstance;

        public static ObjectPooling Instance
        {
            get
            {
                if (_objectPoolingInstance == null)
                {
                    _objectPoolingInstance = FindObjectOfType<ObjectPooling>();
                }
                return _objectPoolingInstance;
            }
        }
        #endregion

        #region Private Variables
        [Header("Reference objects")]
        [SerializeField] public List<SurvivorGameDataModel.Pool> pools = new List<SurvivorGameDataModel.Pool>();
        private Dictionary<SurvivorGameDataModel.PoolObjectType, Queue<GameObject>> poolDictionary = new Dictionary<SurvivorGameDataModel.PoolObjectType, Queue<GameObject>>();
        #endregion

        #region Private Methods
        private void Awake()
        {
            if (_objectPoolingInstance == null)
            {
                _objectPoolingInstance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (_objectPoolingInstance != this)
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            ConstructPools();
        }

        private void ConstructPools()
        {
            foreach (SurvivorGameDataModel.Pool pool in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                for (int i = 0; i < pool.capacity; i++)
                {
                    GameObject obj = Instantiate(pool.poolGameObject);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }
                poolDictionary.Add(pool.PoolObjectType, objectPool);
            }
        }

        public GameObject SpawnFromPool(SurvivorGameDataModel.PoolObjectType poolObjectType, Vector3 position, Quaternion rotation)
        {
            if (!poolDictionary.ContainsKey(poolObjectType))
            {
                return null;
            }

            GameObject objectToSpawn = poolDictionary[poolObjectType].Dequeue();
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            poolDictionary[poolObjectType].Enqueue(objectToSpawn);

            return objectToSpawn;

        }
        #endregion
    }
}
