using DataStoring.Base;
using UnityEngine;

namespace DataStoring.DataStoringPlayerPrefs.Integers.Behaviour
{
    public class DataStoringIntegerPlayerPrefsBehaviour : DataStoringBase<int>
    {
        public override int DoLoadStoredData(string dataSavedName)
        {
            return PlayerPrefs.GetInt(dataSavedName);
        }

        public override void DoSaveData(string dataNameToSave, int dataToSave)
        {
            PlayerPrefs.SetInt(dataNameToSave, dataToSave);
            PlayerPrefs.Save();
        }
    }
}