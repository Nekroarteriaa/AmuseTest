using System.Collections;
using PoolableObjects.Controller;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

namespace Pool.Controller
{
    public class ObjectPoolController : MonoBehaviour
    {
        [SerializeField] 
        private PoolableObjectsController prefabToIntantiate;

        [SerializeField] 
        private int instancesAmount;

        [SerializeField] 
        private Transform pointToPlaceInWorld;

        [SerializeField] 
        private Vector3 pointToPlaceInWorldOffset;

        [SerializeField] 
        private int objectPoolMaxSize = 20;

        [SerializeField] 
        private float maxTimingSpawningInterval = 10;
        
        [SerializeField] 
        private float minTimingSpawningInterval = 0;

        private ObjectPool<PoolableObjectsController> objectPool;
        private GameObject pooledObjectsContainer;

        #region UnityEvents

        private void Awake()
        {
            objectPool = new ObjectPool<PoolableObjectsController>(CreatePoolElements, GetObjectFromPool, DoReturnObjectToPool,
                OnObjectPoolFull, true, instancesAmount, objectPoolMaxSize);
            pooledObjectsContainer = new GameObject($"{prefabToIntantiate.name}Container");
            pooledObjectsContainer.transform.position = Vector2.zero;
        }
        

        #endregion


        public void GetPoolElements()
        {
            StartCoroutine(SpawnObjectInWorld());
        }

        public void StopPooling()
        {
           StopAllCoroutines();
        }

        public void ReturnObjectToPool(PoolableObjectsController pooledObject)
        {
            objectPool.Release(pooledObject);
        }
        
        IEnumerator SpawnObjectInWorld()
        {
            float newInterval = Random.Range(minTimingSpawningInterval, maxTimingSpawningInterval);
            while (true)
            {
                yield return new WaitForSeconds(newInterval);
                objectPool.Get().SetPoolRenference(this);
                newInterval = Random.Range(minTimingSpawningInterval, maxTimingSpawningInterval);
            }
        }

        PoolableObjectsController CreatePoolElements()
        {
            return GameObject.Instantiate(prefabToIntantiate);
        }

        void GetObjectFromPool(PoolableObjectsController pooledObject)
        {
            pooledObject.transform.SetParent(pooledObjectsContainer.transform);
            pooledObject.transform.position = pointToPlaceInWorld.position + pointToPlaceInWorldOffset;
            pooledObject.gameObject.SetActive(true);
        }

        void DoReturnObjectToPool(PoolableObjectsController pooledObject)
        {
            pooledObject.transform.parent = null;
            pooledObject.gameObject.SetActive(false);
        }

        void OnObjectPoolFull(PoolableObjectsController pooledObject)
        {
            Destroy(pooledObject);
        }
    }
}