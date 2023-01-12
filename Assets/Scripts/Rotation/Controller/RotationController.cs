using Rotation.Behaviour;
using UnityEngine;

namespace Rotation.Controller
{
    [RequireComponent(typeof(RotationBehaviour))]
    public class RotationController : MonoBehaviour
    {
        [SerializeField] 
        private Transform transformToRotate;

        [SerializeField] 
        private float rotationDuration;

        [SerializeField] 
        private RotationBehaviour rotationBehaviour;
        
        public void RotateTransform(Vector2 rotationDirection)
        {
            rotationBehaviour.DoRotation(transformToRotate, rotationDirection, rotationDuration);

        }

        public void StopRotation()
        {
           rotationBehaviour.DoStopRotation(transformToRotate);
        }
    }
}