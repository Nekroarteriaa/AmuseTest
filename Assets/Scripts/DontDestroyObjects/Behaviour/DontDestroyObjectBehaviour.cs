using DontDestroyObjects.Interface;
using UnityEngine;

namespace DontDestroyObjects.Behaviour
{
    public class DontDestroyObjectBehaviour : MonoBehaviour, IDontDestroyObject
    {
        public GameObject DesiredGONotToDestroy => desiredGONotToDestroy;
        GameObject desiredGONotToDestroy;
        public void DoNotDestroyDesiredObject(GameObject desiredGO)
        {
            desiredGONotToDestroy = desiredGO;
            DontDestroyOnLoad(desiredGO);
        }

        public void DoDestroyPersistenObject()
        {
            if(desiredGONotToDestroy == null) return;
            GameObject temp = new GameObject("Temp");
            desiredGONotToDestroy.transform.SetParent(temp.transform);
            Destroy(temp);
        }
    }
}