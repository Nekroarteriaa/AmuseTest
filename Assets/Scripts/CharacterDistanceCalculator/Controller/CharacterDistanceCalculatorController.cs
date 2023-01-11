using CharacterDistanceCalculator.Behaviour;
using ScriptableVariables.Float;
using UnityEngine;
using UnityEngine.Events;

namespace CharacterDistanceCalculator.Controller
{
    [RequireComponent(typeof(CharacterDistanceCalculatorBehaviour))]
    public class CharacterDistanceCalculatorController : MonoBehaviour
    {
        [SerializeField] 
        private Transform character;

        [SerializeField] 
        private Transform tranformToCalculateDistance;

        [SerializeField] 
        private ScriptableVariableFloat characterDistanceScriptableVariable;

        [SerializeField]
        private CharacterDistanceCalculatorBehaviour characterDistanceCalculatorBehaviour;

        [SerializeField] 
        private UnityEvent onCharacterDistanceCalculated;
        

        public void CalculateDistance()
        {
            characterDistanceScriptableVariable.SetValue(characterDistanceCalculatorBehaviour.CalculateDistance(tranformToCalculateDistance.position, character.position));
            onCharacterDistanceCalculated.Invoke();
        }
    }
}