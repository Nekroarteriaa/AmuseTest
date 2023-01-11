using ScriptableVariables.Float;
using UnityEngine;

namespace Parallax
{
    public class ParallaxEffectController : MonoBehaviour
    {
        [SerializeField] 
        private Camera virtualCamera;
        
        [SerializeField] 
        private Transform parallaxPlaneToMove;

        [SerializeField]
        private bool canFollowTheCamera;
        
        [SerializeField] [Range(0f,1f)]
        private float panelMovement = 1f;

        [SerializeField] 
        private Renderer selfRenderer;

        [SerializeField][Range(10f, 100f)] 
        private float parallaxEffectIntensity;

        [SerializeField]
        private ScriptableVariableFloat currentMovementMagnitudeScriptableVariable;
        
        private float currentAcceleration;
        
        private float previousAcceleration;
        
        private float currentTime;

        #region UnityEvents

        private void FixedUpdate()
        {
            if(!canFollowTheCamera) return;
            float currentParallaxPositionX = virtualCamera.transform.position.x * panelMovement;
            parallaxPlaneToMove.position = new Vector3(currentParallaxPositionX, parallaxPlaneToMove.position.y, parallaxPlaneToMove.position.z);
        }

        private void LateUpdate()
        {
            if(!canFollowTheCamera) return;
            currentTime += Time.deltaTime;
            CalculateParallaxEffectMovement();
        }

        #endregion
        
        
        void CalculateParallaxEffectMovement()
        {
            if(currentMovementMagnitudeScriptableVariable.Value <= 0 ) return;
            currentAcceleration = CalculateTheEffectAcceleration();
            selfRenderer.material.mainTextureOffset += new Vector2(Mathf.Lerp(previousAcceleration, currentAcceleration, Time.deltaTime), 0) * Time.deltaTime;
            previousAcceleration = currentAcceleration;
        }

        public void OnShoot()
        {
            canFollowTheCamera = true;
        }

        float CalculateTheEffectAcceleration()
        {
            return (currentMovementMagnitudeScriptableVariable.Value) / (currentTime * parallaxEffectIntensity);
        }
    }
}