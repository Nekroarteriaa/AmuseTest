using ScriptableVariables.Float;
using UnityEngine;
using UnityEngine.Events;

namespace EndingGame.Controller
{
    public class EndingGameController : MonoBehaviour
    {
        [SerializeField]
        private ScriptableVariableFloat currentMovementMagnitudeScriptableVariable;
        
        [SerializeField] 
        private UnityEvent onCharacterStoppedScriptableEvent;

        private bool hasLostAllVelocity => currentMovementMagnitudeScriptableVariable.Value <= 0;
        
        private bool hasTheGameFinished = true;

        #region UnityEvents

        private void Update()
        {
            if(hasTheGameFinished) return;
            if(!hasLostAllVelocity) return;
            onCharacterStoppedScriptableEvent.Invoke();
            hasTheGameFinished = true;
        }

        #endregion


        public void GameHasBegun()
        {
            hasTheGameFinished = false;
        }

    }
}