using ScriptableEvents.Interface;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEvents.Void
{
    [CreateAssetMenu(fileName = "ScriptableEventVoid", menuName = "ScriptableEvents/Void", order = 1)]
    public class ScriptableEventVoid : ScriptableObject, IScriptableEvent
    {
        public UnityEvent OnScriptableEvent => onScriptableEvent;
        
        [SerializeField]
        private UnityEvent onScriptableEvent;

        public virtual void InvokeEvent()
        {
            onScriptableEvent.Invoke();
        }
    }
}