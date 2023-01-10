using ScriptableVariables.Boolean;
using SlingshotAimingStripsMovement.Behaviour;
using UnityEngine;

namespace SlingshotAimingStripsMovement.Controller
{
    [RequireComponent(typeof(SlingshotAimingStripsMovementBehaviour))]
    public class SlingshotAimingStripsMovementController : MonoBehaviour
    {
        [SerializeField] 
        private SlingshotAimingStripsMovementBehaviour slingshotAimingStripsMovementBehaviour;
        
        [SerializeField]
        private ScriptableVariableBoolean isAimingScriptableVariable;
        private void Update()
        {
            if(!isAimingScriptableVariable.Value) return;
            slingshotAimingStripsMovementBehaviour.DoAimingMovement();
        }
    }
}