using ScriptableVariables.Boolean;
using Slingshot.Controller;
using SlingshotAiming.Behaviour;
using UnityEngine;
using UnityEngine.Events;

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

        [SerializeField] 
        private UnityEvent onAiming;

        # region UnityEvents
        
        private void Awake()
        {
            slingshotAimingBehaviour.CreateStripsInitialPoint();
        }


        private void Update()
        {

            if(isAimingScriptableVariable.Value)
                slingshotAimingBehaviour.DoAim(currentCamera.ScreenToWorldPoint(Input.mousePosition), centerPoint.position, stripsMaxElasticityScriptableVariable.Value);
            else
                slingshotAimingBehaviour.DoStopAiming(idlePoint.position);
        }

        #endregion
        

        public override void OnFireButtonPressed()
        {
            if(isAimingScriptableVariable.Value) return;
            isAimingScriptableVariable.SetValue(true);
            onAiming.Invoke();
        }

        public override void OnFireButtonReleased()
        {
            if(!isAimingScriptableVariable.Value) return;
            isAimingScriptableVariable.SetValue(false);
        }

        public void StopAiming()
        {
            slingshotAimingBehaviour.DoStopAiming(idlePoint.position);
        }
    }
}