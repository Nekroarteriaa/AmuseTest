using DataStoring.DataStoringPlayerPrefs.Integers.Behaviour;
using ScriptableVariables.Integer;
using UnityEngine;
using UnityEngine.Events;

namespace DataStoring.DataStoringPlayerPrefs.Integers.Controller
{
    [RequireComponent(typeof(DataStoringIntegerPlayerPrefsBehaviour))]
    public class DataStoringIntPlayerPrefsController : MonoBehaviour
    {
        [SerializeField] 
        private string desiredDataName;

        [SerializeField] 
        private ScriptableVariableInt intScriptableVariable;
        
        [SerializeField]
        private DataStoringIntegerPlayerPrefsBehaviour dataStoringFloatPlayerPrefsBehaviour;

        [SerializeField] 
        private UnityEvent onDataLoaded;
        
        [SerializeField] 
        private UnityEvent onDataSaved;

        public void LoadStoredData()
        {
            intScriptableVariable.SetValue(dataStoringFloatPlayerPrefsBehaviour.DoLoadStoredData(desiredDataName));
            onDataLoaded.Invoke();
        }

        public void SaveData(int newData)
        {
            intScriptableVariable.SetValue(newData);
            dataStoringFloatPlayerPrefsBehaviour.DoSaveData(desiredDataName, intScriptableVariable.Value);
            onDataSaved.Invoke();
        }

        public void AddValueToStoredValueByOneUnit()
        {
            intScriptableVariable.SetValue(intScriptableVariable.Value + 1);
            dataStoringFloatPlayerPrefsBehaviour.DoSaveData(desiredDataName, intScriptableVariable.Value);
        }
    }
}