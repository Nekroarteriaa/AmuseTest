namespace ScriptableVariables.Interface
{
    public interface IScriptableVariable<T>
    {
        T Value { get; }

        void SetValue(T valueToSet);
    }
}