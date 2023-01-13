using ScriptableVariables.Integer;
using UnityEngine;
using UnityEngine.Events;

namespace HowToPlay.Controller
{
    public class HowToPlayController : MonoBehaviour
    {
        [SerializeField] 
        private int maximumTimesToShow;

        [SerializeField] 
        private ScriptableVariableInt currentTimesPlayedScriptableVariable;
        
        [SerializeField]
        private UnityEvent onTimesPlayedCompared;

        [SerializeField] 
        private UnityEvent onShowHowToPlay;

        public void CompareValues()
        {
            if ( currentTimesPlayedScriptableVariable.Value < maximumTimesToShow)
            {
                onShowHowToPlay.Invoke();
            }
            onTimesPlayedCompared.Invoke();
        }
    }
}