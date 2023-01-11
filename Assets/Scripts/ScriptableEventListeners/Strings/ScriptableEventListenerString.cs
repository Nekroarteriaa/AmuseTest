using ScriptableEventListeners.Interface;
using ScriptableEvents.BaseArgs;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEventListeners.Strings
{
    public class ScriptableEventListenerString : MonoBehaviour, IScriptableEventListener<string>
    {
        public ScriptableEventBaseArgs<string> ScriptableEventToListen => scriptableEventVoidToListen;
        
        [SerializeField] 
        private ScriptableEventBaseArgs<string> scriptableEventVoidToListen;
        
        [SerializeField] 
        private UnityEvent<string> onScriptableEventResponse;
        
        private void OnEnable()
        {
            scriptableEventVoidToListen.OnScriptableEvent.AddListener(Response);
        }

        private void OnDisable()
        {
            scriptableEventVoidToListen.OnScriptableEvent.RemoveListener(Response);
        }

        private void Response(string args)
        {
            onScriptableEventResponse.Invoke(args);
        }
    }
}