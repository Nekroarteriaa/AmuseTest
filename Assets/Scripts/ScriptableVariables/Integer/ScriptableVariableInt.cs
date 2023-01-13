using ScriptableVariables.Base;
using UnityEngine;

namespace ScriptableVariables.Integer
{
    [CreateAssetMenu(fileName = "ScriptableVariableInt", menuName = "ScriptableVariables/Int", order = 5)]
    public class ScriptableVariableInt : ScriptableVariableBase<int>
    {
        public override int Value { get; }
    }
}