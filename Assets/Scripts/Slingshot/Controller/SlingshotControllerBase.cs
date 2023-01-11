using ScriptableVariables.Float;
using Slingshot.Interface;
using UnityEngine;

namespace Slingshot.Controller
{
    public abstract class SlingshotControllerBase : MonoBehaviour , ISlingshot
    {
        [SerializeField]
        protected Transform centerPoint;

        [SerializeField]
        protected ScriptableVariableFloat stripsMaxElasticityScriptableVariable;

        #region UnityEvents
        
        protected void OnEnable()
        {
            
        }

        protected void OnDisable()
        {
            
        }


        private void OnMouseDown()
        {
            OnFireButtonPressed();
        }

        private void OnMouseUp()
        {
            OnFireButtonReleased();
        }
        

        #endregion

        public abstract void OnFireButtonPressed();
        public abstract void OnFireButtonReleased();
    }
}