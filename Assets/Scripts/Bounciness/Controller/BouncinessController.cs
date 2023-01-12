using Bounce.Interface;
using ScriptableVariables.Float;
using UnityEngine;
using UnityEngine.Events;

namespace Bounciness.Controller
{
    public class BouncinessController : MonoBehaviour
    {
        [SerializeField] 
        private Rigidbody2D characterRigidbody;
        
        [SerializeField] 
        private ScriptableVariableFloat currentMovementMagnitudeScriptableVariable;
        
        [SerializeField]
        private float maxMovementMagnitude;

        private Vector2 lastVelocity;

        [SerializeField] 
        private UnityEvent<Vector2> onTriggerBounceDealed;
        
        [SerializeField] 
        private UnityEvent<Vector2> onCollisionBounceDealed;
        

        #region UnityEvents

        private void Update()
        {
            lastVelocity = characterRigidbody.velocity;
            lastVelocity = Vector3.ClampMagnitude(lastVelocity, maxMovementMagnitude);
            currentMovementMagnitudeScriptableVariable.SetValue(lastVelocity.x);
        } 

        #endregion
        
        public void ApplyBounce(Collision2D collision2D)
        {
            collision2D.gameObject.TryGetComponent(out IBounceDealer bounceDealer);
            if(bounceDealer == null) return;
            bounceDealer.DoBounce(characterRigidbody, collision2D.contacts[0].normal, lastVelocity);
            onCollisionBounceDealed.Invoke(bounceDealer.BounceApplied);
        }

        public void ApplyBounce(Collider2D collider2D)
        {
            collider2D.TryGetComponent(out IBounceDealer bounceDealer);
            if(bounceDealer == null) return;
            Vector2 contactPoint = collider2D.ClosestPoint(characterRigidbody.transform.position);
            bounceDealer.DoBounce(characterRigidbody, contactPoint.normalized, lastVelocity);
            onTriggerBounceDealed.Invoke(bounceDealer.BounceApplied);
        }
        
    }
}