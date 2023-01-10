using Bounce.Interface;
using ScriptableVariables.Float;
using UnityEngine;

namespace Bounciness.Controller
{
    public class BouncinessController : MonoBehaviour
    {
        [SerializeField] 
        private Rigidbody2D rigidbody2D;
        
        [SerializeField] 
        private ScriptableVariableFloat currentMovementMagnitudeScriptableVariable;

        private Vector2 lastVelocity;
        
        private void Update()
        {
            lastVelocity = rigidbody2D.velocity;
            currentMovementMagnitudeScriptableVariable.SetValue(lastVelocity.x);
        }

        public void ApplyBounce(Collision2D collision2D)
        {
            collision2D.gameObject.TryGetComponent(out IBounceDealer bounceDealer);
            if(bounceDealer == null) return;
            bounceDealer.DoBounce(rigidbody2D, collision2D.contacts[0].normal, lastVelocity);
        }

        public void ApplyBounce(Collider2D collider2D)
        {
            collider2D.TryGetComponent(out IBounceDealer bounceDealer);
            if(bounceDealer == null) return;
            Vector2 contactPoint = collider2D.ClosestPoint(rigidbody2D.transform.position);
            bounceDealer.DoBounce(rigidbody2D, contactPoint.normalized, lastVelocity);
        }

        

        
        
    }
}