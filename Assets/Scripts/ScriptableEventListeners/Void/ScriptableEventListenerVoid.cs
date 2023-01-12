using ScriptableEventListeners.Interface;
using ScriptableEvents.Void;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEventListeners.Void
{
    public class ScriptableEventListenerVoid : MonoBehaviour, IScriptableEventListener
    {
        public ScriptableEventVoid ScriptableEventToListen => scriptableEventVoidToListen;
        
        [SerializeField] 
        private ScriptableEventVoid scriptableEventVoidToListen;

        [SerializeField] 
        private UnityEvent onScriptableEventResponse;

        #region UnityEvents
        private void OnEnable()
        {
            scriptableEventVoidToListen.OnScriptableEvent.AddListener(Response);
        }

        private void OnDisable()
        {
            scriptableEventVoidToListen.OnScriptableEvent.RemoveListener(Response);
        }

        private void Response()
        {
            onScriptableEventResponse.Invoke();
        }

        

        #endregion
        
    }
}