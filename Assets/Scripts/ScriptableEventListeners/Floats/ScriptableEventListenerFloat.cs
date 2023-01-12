using ScriptableEventListeners.Interface;
using ScriptableEvents.BaseArgs;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEventListeners.Floats
{
    public class ScriptableEventListenerFloat : MonoBehaviour, IScriptableEventListener<float>
    {
        public ScriptableEventBaseArgs<float> ScriptableEventToListen { get; }
        
        [SerializeField] 
        private ScriptableEventBaseArgs<float> scriptableEventVoidToListen;
        
        [SerializeField] 
        private UnityEvent<float> onScriptableEventResponse;
        
        private void OnEnable()
        {
            scriptableEventVoidToListen.OnScriptableEvent.AddListener(Response);
        }

        private void OnDisable()
        {
            scriptableEventVoidToListen.OnScriptableEvent.RemoveListener(Response);
        }

        private void Response(float args)
        {
            onScriptableEventResponse.Invoke(args);
        }
    }
}