using ScriptableEvents.Interface;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEvents.BaseArgs
{
    public class ScriptableEventBaseArgs<T>: ScriptableObject, IScriptableEvent<T>
    {
        public UnityEvent<T> OnScriptableEvent => onScriptableEvent;

        [SerializeField]
        private UnityEvent<T> onScriptableEvent;

        public virtual void InvokeEvent(T arg)
        {
            onScriptableEvent.Invoke(arg);
        }
    }
}