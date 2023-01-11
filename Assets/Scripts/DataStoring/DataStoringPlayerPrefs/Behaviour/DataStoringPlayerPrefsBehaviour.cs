using DataStoring.Base;
using UnityEngine;

namespace DataStoring.DataStoringPlayerPrefs.Behaviour
{
    public class DataStoringPlayerPrefsBehaviour : DataStoringBase<float>
    {
        public override float DoLoadStoredData(string dataSavedName)
        {
           return PlayerPrefs.GetFloat(dataSavedName);
        }

        public override void DoSaveData(string dataNameToSave, float dataToSave)
        {
            PlayerPrefs.SetFloat(dataNameToSave, dataToSave);
            PlayerPrefs.Save();
        }
    }
}