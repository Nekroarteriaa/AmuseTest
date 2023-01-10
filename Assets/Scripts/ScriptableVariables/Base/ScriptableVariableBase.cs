using ScriptableVariables.Interface;
using UnityEngine;

namespace ScriptableVariables.Base
{
    public abstract class ScriptableVariableBase<T> : ScriptableObject, IScriptableVariable<T>
    {
        public abstract T Value { get; }
        
        [SerializeField] 
        protected T value;
        
        public void SetValue(T valueToSet)
        {
            value = valueToSet;
        }

    }
}