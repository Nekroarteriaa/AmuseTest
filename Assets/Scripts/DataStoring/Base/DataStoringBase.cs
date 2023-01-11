using DataStoring.Interface;
using UnityEngine;

namespace DataStoring.Base
{
    public abstract class DataStoringBase<T>: MonoBehaviour, IDataStoring<T>
    {
        public abstract T DoLoadStoredData(string dataSavedName);
        public abstract void DoSaveData(string dataNameToSave, T dataToSave);
    }
}