using DataStoring.DataStoringPlayerPrefs.Behaviour;
using ScriptableVariables.Float;
using UnityEngine;
using UnityEngine.Events;

namespace DataStoring.DataStoringPlayerPrefs.Controller
{
    [RequireComponent(typeof(DataStoringPlayerPrefsBehaviour))]
    public class DataStoringPlayerPrefsController : MonoBehaviour
    {
        [SerializeField] 
        private string desiredDataName;

        [SerializeField] 
        private ScriptableVariableFloat floatScriptableVariable;
            
        [SerializeField] 
        private DataStoringPlayerPrefsBehaviour dataStoringPlayerPrefsBehaviour;

        [SerializeField] 
        private UnityEvent onDataLoaded;
        
        [SerializeField] 
        private UnityEvent onDataSaved;

        public void LoadStoredData()
        {
            floatScriptableVariable.SetValue(dataStoringPlayerPrefsBehaviour.DoLoadStoredData(desiredDataName));
            onDataLoaded.Invoke();
        }

        public void SaveData(float newData)
        {
            floatScriptableVariable.SetValue(newData);
            dataStoringPlayerPrefsBehaviour.DoSaveData(desiredDataName, floatScriptableVariable.Value);
            onDataSaved.Invoke();
        }
        
    }
}