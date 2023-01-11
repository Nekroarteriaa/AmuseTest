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
        private UnityEvent onScoresCompared;

        [SerializeField] 
        private UnityEvent<float> onNewRecord;

        public void CompareScores()
        {
            if (currentCharacterDistanceScriptableVariable.Value > bestCharacterDistanceScriptableVariable.Value)
                onNewRecord.Invoke(currentCharacterDistanceScriptableVariable.Value);
            onScoresCompared.Invoke();
        }
    }
}