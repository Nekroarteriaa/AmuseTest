using Bounce.Base;
using Enums;
using UnityEngine;

namespace Bounce.Behaviour
{
    public class BounceDealerCollision2D : BounceDealerBehaviourBase
    {
        [SerializeField] 
        private AxisToStop axisToStop;

        public override void DoBounce(Rigidbody2D rigidbody2DToBounce, Vector2 impactNormal, Vector2 currentVelocity)
        {
            if (IsHittingOnAxisToStop(axisToStop, impactNormal))
            {
                CancelBounce(rigidbody2DToBounce);
                return;
            }
            
            base.DoBounce(rigidbody2DToBounce, impactNormal, currentVelocity);
            
        }
        
        bool IsHittingOnAxisToStop(AxisToStop axisToStop, Vector2 impactNormal)
        {
            bool hasHitted = false;
            switch (axisToStop)
            {
                case AxisToStop.X:
                    hasHitted = Mathf.Abs(impactNormal.x) != 0;
                    break;
                case AxisToStop.Y:
                    hasHitted = Mathf.Abs(impactNormal.y) != 0;
                    break;
            }

            return hasHitted;
        }
    }
}