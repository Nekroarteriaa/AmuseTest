using ScriptableEvents.Void;
using ScriptableVariables.Vector2Unity;
using Slingshot.Controller;
using SlingshotShooting.Behaviour;
using UnityEngine;

namespace SlingshotShooting.Controller
{
    [RequireComponent(typeof(SlingshotShootingBehaviour))]
    public class SlingshotShootingController : SlingshotControllerBase
    {
        [SerializeField] 
        private SlingshotShootingBehaviour slingshotShootingBehaviour;

        [SerializeField] 
        private ScriptableVariableVector2 currentStripsPositionScriptableVariable;

        [SerializeField] 
        private ScriptableEventVoid OnShootScriptableEvent;
        
        private bool hasThrownTheBird;

        public override void OnFireButtonPressed()
        {
            slingshotShootingBehaviour.DoPrepareForShooting();
        }

        public override void OnFireButtonReleased()
        {
            if(hasThrownTheBird) return;
            slingshotShootingBehaviour.DoShoot(currentStripsPositionScriptableVariable.Value, centerPoint.position, stripsMaxElasticityScriptableVariable.Value);
            OnShootScriptableEvent.InvokeEvent();
        }
        
        public void StopShooting()
        {
            hasThrownTheBird = true;
        }
    }
}