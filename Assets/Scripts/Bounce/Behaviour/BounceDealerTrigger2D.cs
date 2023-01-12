using Bounce.Base;
using UnityEngine;

namespace Bounce.Behaviour
{
    public class BounceDealerTrigger2D : BounceDealerBehaviourBase
    {
        [SerializeField] 
        private Vector2 extraDirection;

        public override void DoBounce(Rigidbody2D rigidbody2DToBounce, Vector2 impactNormal, Vector2 currentVelocity)
        {
            var direction = Vector2.Reflect(currentVelocity.normalized, impactNormal);
            direction = new Vector2(Mathf.Abs(direction.x), Mathf.Abs(direction.y));
            
            var magnitude = Mathf.Min(currentVelocity.magnitude, BouncinessForceToDeal);
            rigidbody2DToBounce.velocity = Vector2.zero;
            direction += extraDirection;
            rigidbody2DToBounce.AddForce(direction * magnitude , ForceMode2D.Impulse);

            onBounce.Invoke();
            
        }
    }
}