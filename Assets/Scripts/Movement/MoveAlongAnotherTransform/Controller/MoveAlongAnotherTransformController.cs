using System;
using Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace Movement.MoveAlongAnotherTransform.Controller
{
    public class MoveAlongAnotherTransformController : MonoBehaviour
    {
        [SerializeField] 
        private Transform transformToMove;

        [SerializeField] 
        private Transform transformToMoveAlong;

        [SerializeField] 
        private Vector3 offsetPosition;
        
        [SerializeField] [Range(0f,1f)]
        private float movementSpeed = 1f;
        
        [SerializeField] 
        private AxisToFollow axisToFollow;
        
        [FormerlySerializedAs("canFollowTheCamera")] [SerializeField]
        private bool canMoveAlongTransform;

        private Vector3 desiredAxisValueFromTransformToMoveAlong;
        
        #region UnityEvents

        private void FixedUpdate()
        {
            if(!canMoveAlongTransform) return;
            desiredAxisValueFromTransformToMoveAlong = transformToMove.position;
            switch (axisToFollow)
            {
                case AxisToFollow.X:
                    desiredAxisValueFromTransformToMoveAlong.x = transformToMoveAlong.position.x;
                    break;
                case AxisToFollow.Y:
                    desiredAxisValueFromTransformToMoveAlong.y = transformToMoveAlong.position.y;
                    break;
                case AxisToFollow.Z:
                    desiredAxisValueFromTransformToMoveAlong.z = transformToMoveAlong.position.z;
                    break;
                case AxisToFollow.All:
                    desiredAxisValueFromTransformToMoveAlong = transformToMoveAlong.position;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            transformToMove.position = Vector3.Lerp(transformToMove.position,
                (desiredAxisValueFromTransformToMoveAlong + offsetPosition), movementSpeed); //  movementSpeed;
        }
        
        public void BeginToFollow()
        {
            canMoveAlongTransform = true;
        }
        
        #endregion
    }
}