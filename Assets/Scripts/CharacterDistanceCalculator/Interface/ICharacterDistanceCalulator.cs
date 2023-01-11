using UnityEngine;

namespace CharacterDistanceCalculator.Interface
{
    public interface ICharacterDistanceCalulator
    {
        float CalculateDistance(Vector2 initialPoint, Vector2 endPoint);
    }
}