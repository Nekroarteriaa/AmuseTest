using ScriptableVariables.Base;
using UnityEngine;

namespace ScriptableVariables.Boolean
{
    [CreateAssetMenu(fileName = "ScriptableVariableBoolean", menuName = "ScriptableVariables/Boolean", order = 3)]
    public class ScriptableVariableBoolean : ScriptableVariableBase<bool>
    {
        public override bool Value { get => value; }
    }
}