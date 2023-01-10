using ScriptableEvents.BaseArgs;
using ScriptableEvents.Void;

namespace ScriptableEventListeners.Interface
{
    public interface IScriptableEventListener<T>
    {
        ScriptableEventBaseArgs<T> ScriptableEventToListen { get; }
    }
    
    public interface IScriptableEventListener
    {
        ScriptableEventVoid ScriptableEventToListen { get; }
    }
}