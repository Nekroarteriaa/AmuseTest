using ScriptableVariables.Base;
using UnityEngine;

namespace ScriptableVariables.Vector2Unity
{
    [CreateAssetMenu(fileName = "ScriptableVariableVector2", menuName = "ScriptableVariables/Vector2", order = 2)]
    public class ScriptableVariableVector2 : ScriptableVariableBase<Vector2>
    {
        public override Vector2 Value { get => value; }
        
    }
}