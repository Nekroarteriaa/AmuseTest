using UnityEngine;

namespace Rotation.Interface
{
    public interface IRotations
    {
        void DoRotation(Transform tranformToRotate,Vector2 rotationDirection, float duration);
        void DoStopRotation(Transform tranformToStop);
    }
}