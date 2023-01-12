using System.Collections;
using Rotation.Interface;
using UnityEngine;

namespace Rotation.Behaviour
{
    public class RotationBehaviour : MonoBehaviour, IRotations
    {
        [SerializeField] [Range(0f,1f)]
        private float rotationAcceleration;
        private float currentTime;
        public void DoRotation(Transform transformToRotate,Vector2 rotationDirection, float duration)
        {
            StopCoroutine(DoRotationInterp(transformToRotate, rotationDirection, duration));
            currentTime = Mathf.Min(0, duration);
            StartCoroutine(DoRotationInterp(transformToRotate, rotationDirection, duration));
        }

        public void DoStopRotation(Transform transformToRotate)
        {
            StopCoroutine(DoRotationInterp(transformToRotate, Vector2.zero, .5f));
            StartCoroutine(DoRotationInterp(transformToRotate, Vector2.zero, .5f));
        }
        
        IEnumerator DoRotationInterp(Transform transformToRotate, Vector2 rotationDirection,float maxDuration)
        {
            float frameCalculation;
            while (currentTime < maxDuration)
            {
                currentTime += Time.deltaTime;
                frameCalculation = currentTime / maxDuration;
                transformToRotate.Rotate(Vector3.forward * (rotationAcceleration * frameCalculation));
                currentTime = Mathf.Clamp(currentTime, 0, maxDuration);
                yield return null;
            }
        }
    }
}