using Bounce.Interface;
using ScriptableVariables.Float;
using UnityEngine;
using UnityEngine.Events;

namespace Bounce.Base
{
    public abstract class BounceDealerBehaviourBase : MonoBehaviour , IBounceDealer
    {
        public float BouncinessForceToDeal => bouncinessForceToDeal.Value;

        [SerializeField] 
        private ScriptableVariableFloat bouncinessForceToDeal;

        [SerializeField] 
        protected UnityEvent onBounce;

        public virtual void DoBounce(Rigidbody2D rigidbody2DToBounce, Vector2 impactNormal, Vector2 currentVelocity)
        {
            var direction = Vector2.Reflect(currentVelocity.normalized, impactNormal);
            var magnitude = currentVelocity.magnitude;
            rigidbody2DToBounce.velocity = Vector2.zero;
            rigidbody2DToBounce.AddForce(direction * magnitude * BouncinessForceToDeal, ForceMode2D.Impulse);
        }
       
        public void CancelBounce(Rigidbody2D rigidbody2DToBounce)
        {
            rigidbody2DToBounce.velocity = Vector2.zero;
        }
    }
}