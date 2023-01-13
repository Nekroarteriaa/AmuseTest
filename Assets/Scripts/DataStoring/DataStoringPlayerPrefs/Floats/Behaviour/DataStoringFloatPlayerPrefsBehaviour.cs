using DataStoring.Base;
using UnityEngine;

namespace DataStoring.DataStoringPlayerPrefs.Floats.Behaviour
{
    public class DataStoringFloatPlayerPrefsBehaviour : DataStoringBase<float>
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