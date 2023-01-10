using System;
using System.Threading.Tasks;
using ScriptableEvents.Void;
using ScriptableVariables.Boolean;
using ScriptableVariables.Float;
using UnityEngine;

namespace EndingGame.Controller
{
    public class EndingGameController : MonoBehaviour
    {
        [SerializeField]
        private ScriptableVariableFloat currentMovementMagnitudeScriptableVariable;
        [SerializeField] 
        private ScriptableEventVoid onBirdStoppedScriptableEvent;

        private bool hasLostAllVelocity => currentMovementMagnitudeScriptableVariable.Value <= 0;
        private bool hasTheGameFinished = true;

        private void Update()
        {
            if(hasTheGameFinished) return;
            if(!hasLostAllVelocity) return;
            onBirdStoppedScriptableEvent.InvokeEvent();
            hasTheGameFinished = true;
        }

        public void OnShoot()
        {
            _ = WaitToLaunchTheBird();
        }

        async Task WaitToLaunchTheBird()
        {
            await Task.Delay(1000);
            hasTheGameFinished = false;
        }
    }
}