using ScriptableVariables.Float;
using UnityEngine;
using UnityEngine.Events;

namespace Scores.Controller
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] 
        private ScriptableVariableFloat currentCharacterDistanceScriptableVariable;
        
        [SerializeField] 
        private ScriptableVariableFloat bestCharacterDistanceScriptableVariable;

        [SerializeField] 
        private UnityEvent<float> onNewRecord;

        public void CompareScores()
        {
            if(currentCharacterDistanceScriptableVariable.Value <= bestCharacterDistanceScriptableVariable.Value) return;
            onNewRecord.Invoke(currentCharacterDistanceScriptableVariable.Value);
        }
    }
}