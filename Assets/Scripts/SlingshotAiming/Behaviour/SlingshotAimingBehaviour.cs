using ScriptableVariables.Vector2Unity;
using SlingshotAiming.Interface;
using UnityEngine;

namespace SlingshotAiming.Behaviour
{
    public class SlingshotAimingBehaviour : MonoBehaviour, ISlingshotAiming
    {
        [SerializeField]
        private LineRenderer[] lineRenderers;

        [SerializeField] 
        private Transform[] stripPositions;
        
        [SerializeField]
        private float bottomBoundary;

        [SerializeField]
        private ScriptableVariableVector2 currentStripsPositionScriptableVariable;

        private Vector2 currentStripPosition;
        
            
        public void CreateStripsInitialPoint()
        {
            lineRenderers[0].positionCount = 2;
            lineRenderers[1].positionCount = 2;

            lineRenderers[0].SetPosition(0, stripPositions[0].position);
            lineRenderers[1].SetPosition(0, stripPositions[1].position);
        }

        public void DoAim(Vector2 inputPosition, Vector2 centerPointPosition, float stripsMaxElasticity)
        {
            currentStripPosition = inputPosition;
            currentStripPosition = centerPointPosition + Vector2.ClampMagnitude(currentStripPosition - centerPointPosition, stripsMaxElasticity);
            currentStripPosition = ClampBoundary(currentStripPosition);
            SetStripsInPosition(currentStripPosition);
        }

        public void DoStopAiming(Vector2 idleStripPosition)
        {
            currentStripPosition = idleStripPosition;
            SetStripsInPosition(currentStripPosition);
        }

        void SetStripsInPosition(Vector2 position)
        {
            lineRenderers[0].SetPosition(1, position);
            lineRenderers[1].SetPosition(1, position);
            currentStripsPositionScriptableVariable.SetValue(position);
        }
        
        private Vector2 ClampBoundary(Vector2 vectorToClamp)
        {
            vectorToClamp.y = Mathf.Clamp(vectorToClamp.y, bottomBoundary, 1000);
            return vectorToClamp;
        }
    }
}