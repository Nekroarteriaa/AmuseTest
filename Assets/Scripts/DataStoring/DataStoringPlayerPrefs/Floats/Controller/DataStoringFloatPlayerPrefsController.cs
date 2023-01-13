using DataStoring.DataStoringPlayerPrefs.Floats.Behaviour;
using ScriptableVariables.Float;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace DataStoring.DataStoringPlayerPrefs.Floats.Controller
{
    [RequireComponent(typeof(DataStoringFloatPlayerPrefsBehaviour))]
    public class DataStoringFloatPlayerPrefsController : MonoBehaviour
    {
        [SerializeField] 
        private string desiredDataName;

        [SerializeField] 
        private ScriptableVariableFloat floatScriptableVariable;
            
        [FormerlySerializedAs("dataStoringPlayerPrefsBehaviour")] [SerializeField] 
        private DataStoringFloatPlayerPrefsBehaviour dataStoringFloatPlayerPrefsBehaviour;

        [SerializeField] 
        private UnityEvent onDataLoaded;
        
        [SerializeField] 
        private UnityEvent onDataSaved;

        public void LoadStoredData()
        {
            floatScriptableVariable.SetValue(dataStoringFloatPlayerPrefsBehaviour.DoLoadStoredData(desiredDataName));
            onDataLoaded.Invoke();
        }

        public void SaveData(float newData)
        {
            floatScriptableVariable.SetValue(newData);
            dataStoringFloatPlayerPrefsBehaviour.DoSaveData(desiredDataName, floatScriptableVariable.Value);
            onDataSaved.Invoke();
        }
        
    }
}