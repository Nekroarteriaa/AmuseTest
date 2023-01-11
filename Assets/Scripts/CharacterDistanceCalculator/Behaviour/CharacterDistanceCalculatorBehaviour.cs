using CharacterDistanceCalculator.Interface;
using UnityEngine;

namespace CharacterDistanceCalculator.Behaviour
{
    public class CharacterDistanceCalculatorBehaviour : MonoBehaviour, ICharacterDistanceCalulator
    {
        public float CalculateDistance(Vector2 initialPoint, Vector2 endPoint)
        {
            return endPoint.x - initialPoint.x; //Vector2.Distance(initialPoint, endPoint);
        }
    }
}