using ScriptableVariables.Vector2Unity;
using SlingshotAimingStripsMovement.Interface;
using UnityEngine;

namespace SlingshotAimingStripsMovement.Behaviour
{
    public class SlingshotAimingStripsMovementBehaviour : MonoBehaviour, ISlingshotAimingMovement
    {
        [SerializeField] 
        private Transform characterTransform;
        
        [SerializeField] 
        private ScriptableVariableVector2 currentStripPositionScriptableVariable;
        
        [SerializeField] 
        private Transform slingshotCenterPoint;

        [SerializeField] 
        private Vector2 characterOffsetFromCenterPoint;
        
        public void DoAimingMovement()
        {
            Vector2 direction = currentStripPositionScriptableVariable.Value - (Vector2)slingshotCenterPoint.position;
            characterTransform.position = currentStripPositionScriptableVariable.Value + direction.normalized * characterOffsetFromCenterPoint;
            characterTransform.right = -direction.normalized;
        }
    }
}