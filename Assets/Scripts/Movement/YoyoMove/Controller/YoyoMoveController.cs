using System;
using System.Collections;
using DG.Tweening;
using Enums;
using UnityEngine;
using UnityEngine.Serialization;
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
        private int yoyoLoops = -1;

        [SerializeField] 
        private Ease yoyoEase = Ease.InOutSine;

        [SerializeField] 
        private bool randomnessInDistance;
        
        [FormerlySerializedAs("useAbsoluteValues")] [SerializeField] 
        private bool useAbsoluteValuesInRandomnessDistance;

        [SerializeField] 
        private bool killTweenMovementAfterSeconds;

        [SerializeField] 
        private float secondsToKillMovement;

        #region UnityEvents

        private void OnEnable()
        {
            StartCoroutine(WaitForPositioning());
        }

        private void OnDisable()
        {
            transformToMove.DOKill();
            StopCoroutine(WaitForPositioning());
            StopCoroutine(DoKillTweenAfterSeconds(secondsToKillMovement));
        }

        #endregion

        

        IEnumerator WaitForPositioning()
        {
            yield return new WaitForEndOfFrame();
            ApplyMove();
        }
        
        private void ApplyMove()
        {
            Vector3 directionVector = transformToMove.position;
            float distanceToApply = movementDistance;

            if (randomnessInDistance)
                distanceToApply = Random.Range(-movementDistance, movementDistance);
            if (useAbsoluteValuesInRandomnessDistance)
                distanceToApply = Mathf.Abs(distanceToApply);

            switch (desiredDirection)
            {
                case AxisToFollow.X:
                    directionVector.x += distanceToApply;
                    break;
                case AxisToFollow.Y:
                    directionVector.y += distanceToApply;
                    break;
                case AxisToFollow.Z:
                    directionVector.z += distanceToApply;
                    break;
                case AxisToFollow.All:
                    float temp = Random.Range(-movementDistance, movementDistance);
                    directionVector += new Vector3(temp, temp, temp);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            transformToMove.DOMove(directionVector, movementDisplacementDuration).SetLoops(yoyoLoops, LoopType.Yoyo)
                .SetEase(yoyoEase);
            
            if(!killTweenMovementAfterSeconds) return;
            StartCoroutine(DoKillTweenAfterSeconds(secondsToKillMovement));
        }

        IEnumerator DoKillTweenAfterSeconds(float secondsToKill)
        {
            yield return new WaitForSeconds(secondsToKill);
            transformToMove.DOKill();
        }

    }
}