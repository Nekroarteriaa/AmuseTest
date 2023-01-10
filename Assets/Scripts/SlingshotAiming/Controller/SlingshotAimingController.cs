using System;
using ScriptableVariables.Boolean;
using ScriptableVariables.Vector2Unity;
using Slingshot.Controller;
using SlingshotAiming.Behaviour;
using Unity.VisualScripting;
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

        private bool hasThrownTheBird;

        # region UnityEvents
        
        private void Awake()
        {
            slingshotAimingBehaviour.CreateStripsInitialPoint();
        }


        private void Update()
        {
            if(hasThrownTheBird) return;
            
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