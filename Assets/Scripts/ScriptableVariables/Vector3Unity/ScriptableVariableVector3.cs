using ScriptableVariables.Base;
using UnityEngine;

namespace ScriptableVariables.Vector3Unity
{
    [CreateAssetMenu(fileName = "ScriptableVariableVector3", menuName = "ScriptableVariables/Vector3", order = 4)]
    public class ScriptableVariableVector3 : ScriptableVariableBase<Vector3>
    {
        public override Vector3 Value { get; }
    }
}