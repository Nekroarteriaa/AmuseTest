using Bounce.Base;
using UnityEngine;

namespace Bounce.Behaviour
{
    public class BounceDealerTrigger2D : BounceDealerBehaviourBase
    {
        public override void DoBounce(Rigidbody2D rigidbody2DToBounce, Vector2 impactNormal, Vector2 currentVelocity)
        {
            var direction = Vector2.Reflect(currentVelocity.normalized, impactNormal);
            var magnitude = currentVelocity.magnitude;
            rigidbody2DToBounce.velocity = Vector2.zero;
            rigidbody2DToBounce.AddForce(-direction * magnitude * BouncinessForceToDeal, ForceMode2D.Impulse);
        }
    }
}