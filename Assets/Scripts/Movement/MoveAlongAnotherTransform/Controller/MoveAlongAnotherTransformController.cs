using System;
using Enums;
using UnityEngine;

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
        
        [SerializeField]
        private bool canFollowTheCamera;

        private Vector3 desiredAxisValueFromTransformToMoveAlong;
        
        #region UnityEvents

        private void FixedUpdate()
        {
            if(!canFollowTheCamera) return;
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
                    desiredAxisValueFromTransformToMoveAlong.y = transformToMoveAlong.position.z;
                    break;
                case AxisToFollow.All:
                    desiredAxisValueFromTransformToMoveAlong = transformToMoveAlong.position;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            transformToMove.position = (desiredAxisValueFromTransformToMoveAlong + offsetPosition) * movementSpeed;
        }
        
        public void OnShoot()
        {
            canFollowTheCamera = true;
        }
        
        #endregion
    }
}