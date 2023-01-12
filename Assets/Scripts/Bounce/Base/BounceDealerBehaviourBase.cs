using Bounce.Interface;
using ScriptableVariables.Float;
using UnityEngine;
using UnityEngine.Events;

namespace Bounce.Base
{
    public abstract class BounceDealerBehaviourBase : MonoBehaviour , IBounceDealer
    {
        public Vector2 BounceApplied => bounceApplied;
        public float BouncinessForceToDeal => bouncinessForceToDeal.Value;

        [SerializeField] 
        private ScriptableVariableFloat bouncinessForceToDeal;

        [SerializeField] 
        protected UnityEvent onBounce;

        protected Vector2 bounceApplied;

        public virtual void DoBounce(Rigidbody2D rigidbody2DToBounce, Vector2 impactNormal, Vector2 currentVelocity)
        {
            var direction = Vector2.Reflect(currentVelocity.normalized, impactNormal);
            var magnitude = currentVelocity.magnitude;
            rigidbody2DToBounce.velocity = Vector2.zero;
            bounceApplied = direction * magnitude * BouncinessForceToDeal;
            rigidbody2DToBounce.AddForce(bounceApplied, ForceMode2D.Impulse);
        }
       
        public void CancelBounce(Rigidbody2D rigidbody2DToBounce)
        {
            rigidbody2DToBounce.velocity = Vector2.zero;
        }
    }
}