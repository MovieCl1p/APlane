using System.Collections.Generic;
using UnityEngine;

namespace Game.Pool
{
    public class ObjectPooler : MonoBehaviour
    {
        [System.Serializable]
        public class Pool
        {
            public string tag;
            public GameObject prefab;
            public int Counts;
            public Queue<GameObject> QueueItems;
        }

        public static ObjectPooler Instance;

        Pool pooll;
        public List<Pool> poolObjectsList;

        public Dictionary<string, Pool> poolDictionary;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            poolDictionary = new Dictionary<string, Pool>();

            pooll = new Pool();

            foreach (var pool in poolObjectsList)
            {
                pool.QueueItems = new Queue<GameObject>();
                
                for (int i = 0; i < pool.Counts; i++)
                {
                    
                    GameObject obj = Instantiate(pool.prefab);
                    obj.SetActive(false);
                    pool.QueueItems.Enqueue(obj);
                }

                poolDictionary.Add(pool.tag, pool);
            }
        }

        public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
        {
            if (poolObjectsList.Count == 0)
            {
                foreach (var _pool in poolObjectsList)
                {
                    _pool.QueueItems = new Queue<GameObject>();

                    for (int i = 0; i < _pool.Counts; i++)
                    {

                        GameObject obj = Instantiate(_pool.prefab);
                        obj.SetActive(false);
                        _pool.QueueItems.Enqueue(obj);
                    }

                    poolDictionary.Add(_pool.tag, _pool);
                }
            }
            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.LogError("Pool with tag" + "doesnt excist");
                
                return null;
            }

            var pool = poolDictionary[tag];

            if (pool.QueueItems.Count > 0)
            {
                GameObject obj = Instantiate(pool.prefab);
                pool.QueueItems.Enqueue(obj);
            }
            
            GameObject objectToSpawn = pool.QueueItems.Dequeue();
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            IPoolable pooledObj = objectToSpawn.GetComponent<IPoolable>();
            if (pooledObj != null)
            {
                pooledObj.OnSpawn();
            }

            return objectToSpawn;
        }

        public void Return(string tag, GameObject obj)
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                //Debug.LogWarning("Pool with tag" + "doesnt excist");
                return;
            }

            var pool = poolDictionary[tag];
            obj.SetActive(false);
            pool.QueueItems.Enqueue(obj);
        }
    }
}
