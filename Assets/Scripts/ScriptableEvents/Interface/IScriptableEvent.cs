using UnityEngine.Events;

namespace ScriptableEvents.Interface
{
    public interface IScriptableEvent<T>
    {
        UnityEvent<T> OnScriptableEvent { get; }
    }
    
    public interface IScriptableEvent
    {
        UnityEvent OnScriptableEvent { get; }
    }
}