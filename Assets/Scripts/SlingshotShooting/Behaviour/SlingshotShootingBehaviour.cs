using SlingshotShooting.Interface;
using UnityEngine;

namespace SlingshotShooting.Behaviour
{
    public class SlingshotShootingBehaviour : MonoBehaviour, ISlingshotShooting
    {
        [SerializeField] 
        private Rigidbody2D characterRigidbody2D;
        
        

        [SerializeField] 
        private float shootingForce;

        public void DoPrepareForShooting()
        {
            characterRigidbody2D.isKinematic = true;
            characterRigidbody2D.velocity = Vector2.zero;
            characterRigidbody2D.angularVelocity = 0f;
        }

        public void DoShoot(Vector2 stripsPosition, Vector2 centerPointPosition, float stripsMaxElasticity)
        {
            characterRigidbody2D.isKinematic = false;
            Vector2 direction = (centerPointPosition - stripsPosition).normalized;
            Vector2 stripMagnitude = Vector2.ClampMagnitude(stripsPosition - centerPointPosition, stripsMaxElasticity);
            stripMagnitude.x = (stripMagnitude.x > 0) ? -stripMagnitude.x : stripMagnitude.x;
            stripMagnitude.y = (stripMagnitude.y > 0.5f) ? -stripMagnitude.y : stripMagnitude.y;
            characterRigidbody2D.AddForce(-direction * (stripMagnitude * shootingForce), ForceMode2D.Impulse);
        }
    }
}