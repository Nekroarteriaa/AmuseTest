using UnityEngine;

namespace DontDestroyObjects.Interface
{
    public interface IDontDestroyObject
    {
        GameObject DesiredGONotToDestroy { get; }
        void DoNotDestroyDesiredObject(GameObject desiredGO);
        void DoDestroyPersistenObject();
    }
}