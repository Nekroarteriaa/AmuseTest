using DontDestroyObjects.Behaviour;
using UnityEngine;

namespace DontDestroyObjects.Controller
{
    [RequireComponent(typeof(DontDestroyObjectBehaviour))]
    public class DontDestroyObjectController : MonoBehaviour
    {
        [SerializeField] 
        private Transform objectNotToDestroy;

        [SerializeField]
        private DontDestroyObjectBehaviour dontDestroyObjectBehaviour;

        private void Awake()
        {
            dontDestroyObjectBehaviour.DoNotDestroyDesiredObject(objectNotToDestroy.gameObject);
        }

        public void StopPersistance()
        {
            dontDestroyObjectBehaviour.DoDestroyPersistenObject();
        }
    }
}