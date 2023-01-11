using ScriptableVariables.Boolean;
using Slingshot.Controller;
using SlingshotAiming.Behaviour;
using UnityEngine;

namespace SlingshotAiming.Controller
{
    [RequireComponent(typeof(SlingshotAimingBehaviour))]
    public class SlingshotAimingController : SlingshotControllerBase
    {
        [SerializeField] 
        protected Transform idlePoint;
        
        [SerializeField] 
        private Camera currentCamera;
        
        [SerializeField] 
        private SlingshotAimingBehaviour slingshotAimingBehaviour;
        
        [SerializeField]
        private ScriptableVariableBoolean isAimingScriptableVariable;

        private bool hasThrownTheCharacter;

        # region UnityEvents
        
        private void Awake()
        {
            slingshotAimingBehaviour.CreateStripsInitialPoint();
        }


        private void Update()
        {
            if(hasThrownTheCharacter) return;
            
            if(isAimingScriptableVariable.Value)
                slingshotAimingBehaviour.DoAim(currentCamera.ScreenToWorldPoint(Input.mousePosition), centerPoint.position, stripsMaxElasticityScriptableVariable.Value);
            else
                slingshotAimingBehaviour.DoStopAiming(idlePoint.position);
        }

        #endregion
        

        public override void OnFireButtonPressed()
        {
            isAimingScriptableVariable.SetValue(true);
        }

        public override void OnFireButtonReleased()
        {
            isAimingScriptableVariable.SetValue(false);
        }

        public void StopAiming()
        {
            slingshotAimingBehaviour.DoStopAiming(idlePoint.position);
        }
    }
}