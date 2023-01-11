using Pool.Controller;
using UnityEngine;
using UnityEngine.Events;

namespace PoolableObjects.Controller
{
    public class PoolableObjectsController : MonoBehaviour
    {
        private ObjectPoolController poolController;

        [SerializeField] 
        private UnityEvent onReturnToPool;

        public void SetPoolRenference(ObjectPoolController controller)
        {
            poolController = controller;
        }

        public void ReturnObjectToPool()
        {
            onReturnToPool.Invoke();
            poolController.ReturnObjectToPool(this);
        }
    }
}