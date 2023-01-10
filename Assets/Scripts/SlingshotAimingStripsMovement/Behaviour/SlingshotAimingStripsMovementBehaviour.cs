using ScriptableVariables.Vector2Unity;
using SlingshotAimingMovement.Interface;
using UnityEngine;

namespace SlingshotAimingStripsMovement.Behaviour
{
    public class SlingshotAimingStripsMovementBehaviour : MonoBehaviour, ISlingshotAimingMovement
    {
        [SerializeField] 
        private Transform birdTransform;
        
        [SerializeField] 
        private ScriptableVariableVector2 currentStripPositionScriptableVariable;
        
        [SerializeField] 
        private Transform slingshotCenterPoint;

        [SerializeField] 
        private Vector2 birdOffsetFromCenterPoint;
        
        public void DoAimingMovement()
        {
            Vector2 direction = currentStripPositionScriptableVariable.Value - (Vector2)slingshotCenterPoint.position;
            birdTransform.position = currentStripPositionScriptableVariable.Value + direction.normalized * birdOffsetFromCenterPoint;
            birdTransform.right = -direction.normalized;
        }
    }
}