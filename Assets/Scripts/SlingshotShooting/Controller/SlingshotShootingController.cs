using ScriptableVariables.Vector2Unity;
using Slingshot.Controller;
using SlingshotShooting.Behaviour;
using UnityEngine;
using UnityEngine.Events;

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
        private UnityEvent OnShootScriptableEvent;
        
        private bool hasThrownTheCharacter;

        public override void OnFireButtonPressed()
        {
            slingshotShootingBehaviour.DoPrepareForShooting();
        }

        public override void OnFireButtonReleased()
        {
            if(hasThrownTheCharacter) return;
            slingshotShootingBehaviour.DoShoot(currentStripsPositionScriptableVariable.Value, centerPoint.position, stripsMaxElasticityScriptableVariable.Value);
            OnShootScriptableEvent.Invoke();
        }
        
        public void StopShooting()
        {
            hasThrownTheCharacter = true;
        }
    }
}