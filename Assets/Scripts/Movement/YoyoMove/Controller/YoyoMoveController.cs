using System;
using DG.Tweening;
using Enums;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Movement.YoyoMove.Controller
{
    public class YoyoMoveController : MonoBehaviour
    {
        [SerializeField] 
        private Transform transformToMove;

        [SerializeField] 
        private AxisToFollow desiredDirection;

        [SerializeField] 
        private float movementDistance;

        [SerializeField] 
        private float movementDisplacementDuration;

        [SerializeField] 
        private bool useAbsoluteValues;

        [SerializeField] 
        private bool randomnessInDistance;

        private void OnEnable()
        {
            Vector3 directionVector = transformToMove.position;
            float distanceToApply = movementDistance;
            
            if(randomnessInDistance)
               distanceToApply = Random.Range(-movementDistance, movementDistance);
            if (useAbsoluteValues)
                distanceToApply = Mathf.Abs(distanceToApply);
            
            switch (desiredDirection)
            {
                case AxisToFollow.X:
                    directionVector.x += distanceToApply;
                    break;
                case AxisToFollow.Y:
                    directionVector.y +=  distanceToApply;
                    break;
                case AxisToFollow.Z:
                    directionVector.z += distanceToApply;
                    break;
                case AxisToFollow.All:
                    float temp = Random.Range(-movementDistance, movementDistance);
                    directionVector +=  new Vector3(temp, temp, temp);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            transformToMove.DOMove(directionVector, movementDisplacementDuration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        }
    }
}