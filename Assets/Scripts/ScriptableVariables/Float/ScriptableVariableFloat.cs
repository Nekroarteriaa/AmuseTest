using ScriptableVariables.Base;
using UnityEngine;

namespace ScriptableVariables.Float
{
    [CreateAssetMenu(fileName = "ScriptableVariableFloat", menuName = "ScriptableVariables/Float", order = 1)]
    public class ScriptableVariableFloat : ScriptableVariableBase<float>
    {
        public override float Value { get => value; }
    }
}