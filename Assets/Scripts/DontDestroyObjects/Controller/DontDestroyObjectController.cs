using UnityEngine;

namespace DontDestroyObjects.Controller
{
    public class DontDestroyObjectController : MonoBehaviour
    {
        [SerializeField] 
        private Transform objectNotToDestroy;

        private void Awake()
        {
            DontDestroyOnLoad(objectNotToDestroy.gameObject);
        }

        public void StopPersistance()
        {
            GameObject temp = new GameObject("Temp");
           objectNotToDestroy.SetParent(temp.transform);
            Destroy(temp);
        }
    }
}